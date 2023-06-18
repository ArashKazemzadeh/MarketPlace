using Application.IServices.SellerServices.ImageServices.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductImageCommandsService _productImageCommandsService;

        public ImageController(IWebHostEnvironment webHostEnvironment, IProductImageCommandsService productImageCommandsService)
        {
            _webHostEnvironment = webHostEnvironment;
            _productImageCommandsService = productImageCommandsService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(int productId, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return BadRequest("No photo uploaded.");
            }

            try
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

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

                string imageUrl = "/uploads/" + uniqueFileName;

                await _productImageCommandsService.AddImageToProduct(productId, imageUrl);

                return RedirectToAction("Detail", "Product", new { id = productId });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error uploading photo: {ex.Message}");
            }
        }

        public async Task<IActionResult> DeleteImage(string imageUrl)
        {
            try
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string imagePath = Path.Combine(webRootPath, "uploads", Path.GetFileName(imageUrl));

                // حذف عکس از دیتابیس
                await _productImageCommandsService.DeleteImageFromProduct(imageUrl);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);

                return RedirectToAction("Detail","Product");
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting image: {ex.Message}");
            }
        }





    }
}