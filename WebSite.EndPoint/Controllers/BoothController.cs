using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.CustomerServices.CategoryServices;
using Application.IServices.CustomerServices.CommentServices.Queries;
using Application.IServices.CustomerServices.ProductServices.Queries;
using Application.IServices.CustomerServices.SellerServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebSite.EndPoint.Areas.Admin.Models;
using WebSite.EndPoint.Models.ViewModels;

namespace WebSite.EndPoint.Controllers
{
   
    public class BoothController : Controller
    {
        private readonly IGetBoothsByCategoryId _getBoothsByCategoryId;
        private readonly ICategoryCustomerQueryService _categoryCustomerQueryService;
        private readonly IGetAllProductsByBoothIdService _allProductsByBoothIdService;
        private readonly ICommentQueryService _commentQueryService;
        private readonly IGetProductDetailByIdService _getProductDetailById;
        public BoothController(
            IGetBoothsByCategoryId getBoothsByCategory,
            ICategoryCustomerQueryService categoryCustomerQueryService,
            IGetAllProductsByBoothIdService allProductsByBoothIdService,
            ICommentQueryService commentQueryService,
            IGetProductDetailByIdService getProductDetailById)
        {
            _getBoothsByCategoryId = getBoothsByCategory;
            _categoryCustomerQueryService = categoryCustomerQueryService;
            _allProductsByBoothIdService = allProductsByBoothIdService;
            _commentQueryService = commentQueryService;
            _getProductDetailById = getProductDetailById;
        }
        //public async Task<IActionResult> GetCommentByProductId(int productId)
        //{
        //    var result = await _commentQueryService.GetCommentByProductId(productId);
        //    var model = result.Select(c => new GetCommentVM
        //    {
        //        Id = c.Id,
        //        ProductName = c.Product.Name,
        //        Title = c.Title,
        //        Description = c.Description,
        //        RegisterDate = c.RegisterDate,
        //        UserName =  c.CustomerId.ToString()
        //    }).ToList();
        //    return View(model);
        //}
        public async Task<IActionResult> GetBoothByCategoryId(int categoryid)
        {
            var dto = await _getBoothsByCategoryId.Execute(categoryid);
            var models = dto.Select(b => new BoothVM
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                Seller = b.SellerName
            }).ToList();

            return View(models);
        }

        public async Task<IActionResult> GetAllCategories()
        {
            var dto = await _categoryCustomerQueryService.GetAllCategory();
            return View(dto);
        }

        public async Task<IActionResult> EnterToBooth(int boothId)
        {
            var dto = await _allProductsByBoothIdService.Execute(boothId);
            var model = dto.Select(p => new ProductForCustomerVM
            {
                Id = p.Id,
                BoothId = p.BoothId,
                Name = p.Name,
                BasePrice = p.BasePrice,
                Availability = p.Availability,
                Description = p.Description,
                BoothName = p.BoothName,
                ImagesUrls = p.ImagesUrls,
                Categories = p.Categories,
            }).ToList();
            ViewBag.Message = TempData["AddToCartBasePrice"];
            ViewBag.ProductDetail = TempData["ProductDetail"] = "کالاموجود نیست";
            return View(model);

        }

        public async Task<IActionResult> ProductDetail(int productId,int boothId)
        {
            var product = await _getProductDetailById.Execute(productId);
            if (product.message== "Null")
            {
                TempData["ProductDetail"] = "کالاموجود نیست";
                return RedirectToAction("EnterToBooth",new{boothId= boothId });
            }

            var model = new ProductForCustomerVM
            {
               BoothId = boothId,
                Id = product.Data.Id,
                Name = product.Data.Name,
                BasePrice = product.Data.BasePrice,
                Availability = product.Data.Availability,
                Description = product.Data.Description,
                ImagesUrls = product.Data.Image.Select(url=>url.Url).ToList(),
                Categories = product.Data.Categories.Select(name => name.Name).ToList(),
                IsAuction = product.Data.IsAuction
            };
           
            return View(model);
        }
    }
}
