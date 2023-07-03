using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.Visitors;
using Application.Services.AdminServices.UserServices.AllUserService;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.Image;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileImageService _imageService;
        private readonly IAccountService _accountService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProfileController(IProfileImageService imageService, IAccountService accountService, IWebHostEnvironment webHostEnvironment)
        {
            _imageService = imageService;
            _accountService = accountService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> UploadProfileImage()//seller
        {
            var seInUserId = await _accountService.GetLoggedInUserId();
            if (seInUserId == null)
            {
                ViewBag.Message = "ابتدا لاگین کنید سپس برای ذخیره عکس اقدام نمایید.";
                return View();
            }

            var model = new ImageUserDto
            {
                SellerId = Convert.ToInt32(seInUserId)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(int sellerId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "عکس را انتخاب کنید سپس برای ذخیره اقدام کنید";
                return View();
            }

            var image = await _imageService.GetProfileImage(sellerId);
            if (image.Data != null)
            {
                // کد برای حذف عکس از پوشه wwwroot
                // به عنوان مثال:
                var imagePathExist = Path.Combine(webHostEnvironment.WebRootPath, image.Data.Url.TrimStart('/'));
                if (System.IO.File.Exists(imagePathExist))
                {
                    System.IO.File.Delete(imagePathExist);
                }
                await _imageService.DeleteProfileImage(image.Data.Id);
            }

            // ایجاد پوشه در صورت عدم وجود
            var profileImgPath = Path.Combine(webHostEnvironment.WebRootPath, "ProfileImg");
            if (!Directory.Exists(profileImgPath))
            {
                Directory.CreateDirectory(profileImgPath);
            }

            // کد برای ذخیره عکس در پوشه profileimg و بازگرداندن URL آن
            // به عنوان مثال:
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var imagePath = Path.Combine(profileImgPath, fileName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var imageUrl = "/ProfileImg/" + fileName;
            var uploadMessage = await _imageService.UploadProfileImage(sellerId, imageUrl);
            var newImage = new ImageUserAddDto
            {
                SellerId = sellerId,
                Url = imageUrl
            };
            if (uploadMessage)
            {
                ViewBag.Message = "عکس با موفقیت بارگذاری شد.";
                return RedirectToAction("Index", "Home", new { area = "Seller" });
            }
            else
            {
                ViewBag.Message = "عملیات با شکست مواجه شد";
                return RedirectToAction("Index", "Home", new { area = "Seller" });
            }
        }

    }
}
