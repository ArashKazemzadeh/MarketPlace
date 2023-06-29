using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.SellerServices.ImageServices.Commands;
using Application.IServices.SellerServices.ImageServices.Queries;
using Application.Services.SellerServices.ImageServices.Commands;
using Domin.IRepositories.Dtos.File;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Formats.Jpeg;
using WebSite.EndPoint.Areas.Seller.Models;

namespace WebSite.EndPoint.Areas.Seller.Controllers;

[Area("seller")]
public class FileController : Controller
{
    private readonly IFileCommandService _fileCommandService;
    private readonly IFilesQueryService _filesQueryService;
    private readonly IAccountService _accountService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public FileController(IFileCommandService commandService,
        IFilesQueryService filesQueryService, IAccountService accountService,
        IWebHostEnvironment webHostEnvironment)
    {
        _fileCommandService = commandService;
        _filesQueryService = filesQueryService;
        _accountService = accountService;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> FileManager()
    {
        var sellerStringId = await _accountService.GetLoggedInUserId();
        if (sellerStringId == null)
        {
            ViewBag.Message = "شما لاگین نیستید";
            return View();
        }
        var sellerId = Convert.ToInt32(sellerStringId);
        var dto = await _filesQueryService.GetAllFilesBySellerId(sellerId);
        var model = dto.Select(f => new FileGetVM()
        {
            Id = f.Id,
            Name = f.Name,
            Url = f.Url,
            SellerId = sellerId
        }).ToList();
        if (TempData["FileMessage"] != null)
        {
            ViewBag.Message = TempData["FileMessage"];

        }
        return View(model);
    }

    public async Task<IActionResult> Create(string name, IFormFile photo)
    {
        var sellerStringId = await _accountService.GetLoggedInUserId();
        if (sellerStringId == null)
        {
            TempData["FileMessage"] = "شما لاگین نیستید";
            return View();
        }
        var sellerId = Convert.ToInt32(sellerStringId);
        try
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "sellerFiles");

            // بررسی وجود پوشه و ایجاد آن در صورت عدم وجود
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid() + "_" + photo.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await photo.CopyToAsync(fileStream);
            }

            string imageUrl = "/sellerFiles/" + uniqueFileName;
            var dto = new FileAddDto
            {
                Name = name,
                SellerId = sellerId,
                Url = imageUrl
            };
            var result = await _fileCommandService.UploadFile(sellerId, dto);
            if (result == "عملیات با موفقیت انجام شد.")
            {
                TempData["FileMessage"] = result;
                return RedirectToAction("FileManager", "File");
            }
            TempData["FileMessage"] = result;
            return RedirectToAction("FileManager", "File");

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error uploading file: {ex.Message}");
        }

    }

    public async Task<IActionResult> Delete(int fileId)
    {
        var file = await _filesQueryService.GetFile(fileId);
        if (file == null)
        {
            TempData["FileMessage"] = "فایل موجودنیست.";
            return RedirectToAction("FileManager", "File");
        }

        var result = await _fileCommandService.DeleteFile(fileId);
        if (result!= "عملیات با موفقیت انجام شد.")
        {
            TempData["FileMessage"] = result;
            return RedirectToAction("FileManager", "File");
        }

        string webRootPath = _webHostEnvironment.WebRootPath;
        string imagePath = Path.Combine(webRootPath, "sellerFiles", Path.GetFileName(file.Url));

        if (System.IO.File.Exists(file.Url))
            System.IO.File.Delete(file.Url);

        TempData["FileMessage"] = result;
        return RedirectToAction("FileManager", "File");

    }

       
    
}

