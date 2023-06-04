using Application.IServices.AdminServices.ProoductServices.Commands;
using Application.IServices.AdminServices.ProoductServices.Queries;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Admin.Models;

namespace WebSite.EndPoint.Areas.Admin.Controllers
{
   [Area("Admin")]
   public class ProductController : Controller
   {
       private readonly IGetProductsWithSellerNameAsyncService _allProductsWithSellerNameAsyncService;
       private readonly IUpdateProductAdminService _updateProductAdminService;
       private readonly IDeleteProductAdminService _deleteProductAdminService;
       private readonly IGetProductByIdService _getProductByIdService;
       public ProductController(
           IGetProductsWithSellerNameAsyncService allProductsWithSellerNameAsyncService,
           IDeleteProductAdminService deleteProductAdminService, // اضافه کردن IDeleteProductAdminService
           IUpdateProductAdminService updateProductAdminService,
           IGetProductByIdService getProductByIdService)
       {
           _allProductsWithSellerNameAsyncService = allProductsWithSellerNameAsyncService;
           _deleteProductAdminService = deleteProductAdminService; // اضافه کردن IDeleteProductAdminService
           _updateProductAdminService = updateProductAdminService;
           _getProductByIdService = getProductByIdService;
       }
        public async Task< IActionResult> Index()
       {
           var products = await _allProductsWithSellerNameAsyncService.ExecuteAll();
          
            return View(products);
        }
       public async Task<IActionResult> Delete(int id)
       {
           var result =await _deleteProductAdminService.Execute(id);
           return RedirectToAction("Index");
       }
       public async Task<IActionResult> Edit(int id)
       {
           var product =await _getProductByIdService.Execute(id);
           var productVM = new ProductVm
           {
               Id = product.Data.Id,
               Name = product.Data.Name,//
               Availability = product.Data.Availability,//
               BasePrice = product.Data.BasePrice,//
               Description = product.Data.Description,//
               IsAuction = product.Data.IsAuction,//
               IsConfirm = product.Data.IsConfirm,
               IsActive = product.Data.IsActive,//
        };
          
           return View(productVM);
       }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductVm model)
       {
           var product = await _getProductByIdService.Execute(model.Id);
           product.Data.Name = model.Name;
           product.Data.Availability = model.Availability;
           product.Data.BasePrice = model.BasePrice;
           product.Data.Description = model.Description;
           product.Data.IsAuction = model.IsAuction;
           product.Data.IsConfirm = model.IsConfirm;
           product.Data.IsActive = model.IsAuction;
           var result = await _updateProductAdminService.Execute(product.Data);
           return RedirectToAction("Index");
       }
    }
}
