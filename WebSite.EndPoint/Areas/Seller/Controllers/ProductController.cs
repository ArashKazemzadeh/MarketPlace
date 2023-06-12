using Application.Dtos.ProductDto;
using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.SellerServices.ImageServices.Commands;
using Application.IServices.SellerServices.ProductServices.Commands;
using Application.IServices.SellerServices.ProductServices.Queries;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Seller.Models;

namespace WebSite.EndPoint.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ProductController : Controller
    {
        private readonly IAddProductTooBoothSellerService _addProductTooBoothSellerService;
        private readonly IUpdateProductSellerService _updateProductSellerService;
        private readonly IDeleteProductSellerService _deleteProductSellerService;
        private readonly IGetProductSellerService _getProductSellerService;
        private readonly IProductImageQueriesService _productImageQueriesService;
        private readonly IAccountService _accountService;

        public ProductController(IAddProductTooBoothSellerService addProductTooBoothSellerService,
            IGetProductSellerService getProductSellerService, IAccountService accountService,
            IUpdateProductSellerService updateProductSellerService,
            IProductImageQueriesService productImageQueriesService,
            IDeleteProductSellerService deleteProductSellerService)
        {
            _addProductTooBoothSellerService = addProductTooBoothSellerService;
            _getProductSellerService = getProductSellerService;
            _accountService = accountService;
            _updateProductSellerService = updateProductSellerService;
            _productImageQueriesService = productImageQueriesService;
            _deleteProductSellerService = deleteProductSellerService;
        }
        public async Task<IActionResult> Index()
        {
            var SellerId = Convert.ToInt32(await _accountService.GetLoggedInUserId());
            var productDtos = await _getProductSellerService.GetAllProductBySellerIdAsync(SellerId);
            var tasks = productDtos.Data.Select(async p =>
            {
                var urls = await _productImageQueriesService.GetImageUrlForProduct(p.Id);
                return new ProductSellerVm
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    BasePrice = p.BasePrice,
                    IsActive = p.IsActive,
                    IsAuction = p.IsAuction,
                    IsConfirm = p.IsConfirm,
                    Availability = p.Availability,
                    ImagedUrls = urls
                };
            }).ToList();

            var result = await Task.WhenAll(tasks); // انتظار برای اتمام همه تسک‌ها و بازگشت آرایه‌ای از نتایج

            return View(result.ToList()); // تبدیل آرایه به لیست
        }
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _getProductSellerService.FindByIdAsync(id);
            var urls = await _productImageQueriesService.GetImageUrlForProduct(product.Data.Id);
            var model = new ProductSellerVm
            {
                ProductId = product.Data.Id,
                Name = product.Data.Name,
                BasePrice = product.Data.BasePrice,
                Availability = product.Data.Availability,
                Description = product.Data.Description,
                ImagedUrls = urls
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddProductVm model)
        {
            var SellerId = Convert.ToInt32(await _accountService.GetLoggedInUserId());
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            var newProduct = new ProductForAddDto
            {
                Name = model.Name,
                BasePrice = model.BasePrice,
                Description = model.Description,
                Availability = model.Availability
            };
            var result = await _addProductTooBoothSellerService.Execute(newProduct, SellerId);
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var productgeneral = await _getProductSellerService.FindByIdAsync(id);
            var model = new ProductForUpdateDto
            {   
                Id = id,
                Name = productgeneral.Data.Name,
                BasePrice = productgeneral.Data.BasePrice,
                Description = productgeneral.Data.Description,
                Availability = productgeneral.Data.Availability
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductForUpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _updateProductSellerService.Execute(model);
            ViewBag.Message = result;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _deleteProductSellerService.Execute(id);
            return RedirectToAction("Index");
        }
    }
}
