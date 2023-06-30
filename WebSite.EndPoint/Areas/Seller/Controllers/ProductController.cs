using Application.Dtos.ProductDto;
using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.SellerServices.CategoryService;
using Application.IServices.SellerServices.ImageServices.Commands;
using Application.IServices.SellerServices.ProductServices.Commands;
using Application.IServices.SellerServices.ProductServices.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IGetCategoryServices _getCategoryServices;
        private readonly IAddProductToCategoryService _addProductToCategoryService;
        public ProductController(IAddProductTooBoothSellerService addProductTooBoothSellerService,
            IGetProductSellerService getProductSellerService, IAccountService accountService,
            IUpdateProductSellerService updateProductSellerService,
            IProductImageQueriesService productImageQueriesService,
            IDeleteProductSellerService deleteProductSellerService, IGetCategoryServices getCategoryServices, IAddProductToCategoryService addProductToCategoryService)
        {
            _addProductTooBoothSellerService = addProductTooBoothSellerService;
            _getProductSellerService = getProductSellerService;
            _accountService = accountService;
            _updateProductSellerService = updateProductSellerService;
            _productImageQueriesService = productImageQueriesService;
            _deleteProductSellerService = deleteProductSellerService;
            _getCategoryServices = getCategoryServices;
            _addProductToCategoryService = addProductToCategoryService;
        }
       
        public async Task<IActionResult> Index()
        {
            var sellerId = Convert.ToInt32(await _accountService.GetLoggedInUserId());
            var productDtos = await _getProductSellerService.GetAllProductBySellerIdAsync(sellerId);

            var result = new List<ProductSellerVm>();

            foreach (var p in productDtos.Data)
            {
                var images = await _productImageQueriesService.GetImagesForProductAsync(p.Id);
                var urls = images.Select(i => i.Url).ToList();

                var productSellerVm = new ProductSellerVm
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    BasePrice = p.BasePrice,
                    IsActive = p.IsActive,
                    IsAuction = p.IsAuction,
                    IsConfirm = p.IsConfirm,
                    Availability = p.Availability,
                    ImagedUrls = urls,
                    Categories = p.Categories
                };

                result.Add(productSellerVm);
            }

            return View(result);
        }

        public async Task<IActionResult> Detail(int id) //productId
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
                ImagedUrls = urls   ,
                IsAuction = product.Data.IsAuction,
                Categories=product.Data.Categories
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _getCategoryServices.GetAll();
            var categoryList = new SelectList(categories, "Id", "Name");

            var model = new AddProductVm();
            model.CategoryList = categoryList;

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddProductVm model)
        {
            var sellerId = Convert.ToInt32(await _accountService.GetLoggedInUserId());
           

            var newProduct = new ProductForAddDto
            {
                Name = model.Name,
                BasePrice = model.BasePrice.Value,
                Description = model.Description,
                Availability = model.Availability.Value
            };

            var result = await _addProductTooBoothSellerService.Execute(newProduct, sellerId);

            if (result!=0 && result!=null)
            {
                // افزودن محصول به دسته بندی
                var categoryId = model.CategoryId;
                var addProductToCategoryResult = await _addProductToCategoryService.Execute(result, categoryId);

                if (addProductToCategoryResult == "محصول با موفقیت به دسته بندی اضافه شد.")
                {
                    return RedirectToAction("Detail", new { id = result});

                }
                ModelState.AddModelError("", addProductToCategoryResult);
                
            }
            else
            {
                ModelState.AddModelError("", "افزودن کالا با خطا مواجه شده است.");
            }

            // دریافت لیست دسته بندی‌ها
            var categories = await _getCategoryServices.GetAll();

            // ساخت SelectList از لیست دسته بندی‌ها
            model.CategoryList = new SelectList(categories, "Id", "Name");

            return View(model);
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
                Availability = productgeneral.Data.Availability,
                // اضافه کردن دسته‌بندی‌های محصول در مدل
                CategoryIds = productgeneral.Data.Categories.Select(c => c.Id).ToList()
            };
            // ارسال دسته‌بندی‌ها به ویو
            ViewBag.Categories = await _getCategoryServices.GetAll(); // جایگزین کردن _categoryRepository با مخزن (repository) مربوطه

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductForUpdateDto model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
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
