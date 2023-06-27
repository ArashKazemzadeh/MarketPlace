using Application.IServices.CustomerServices.CategoryServices;
using Application.IServices.CustomerServices.CommentServices.Queries;
using Application.IServices.CustomerServices.ProductServices.Queries;
using Application.IServices.CustomerServices.SellerServices.Queries;
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
        public BoothController(IGetBoothsByCategoryId getBoothsByCategory,
            ICategoryCustomerQueryService categoryCustomerQueryService,
            IGetAllProductsByBoothIdService allProductsByBoothIdService, 
            ICommentQueryService commentQueryService)
        {
            _getBoothsByCategoryId = getBoothsByCategory;
            _categoryCustomerQueryService = categoryCustomerQueryService;
            _allProductsByBoothIdService = allProductsByBoothIdService;
            _commentQueryService = commentQueryService;
        }
        public async Task<IActionResult> GetCommentByProductId(int productId)
        {
            var result = await _commentQueryService.GetCommentByProductId(productId);
            return View(result);
        }
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
           var dto=await _categoryCustomerQueryService.GetAllCategory();
           return View(dto);
        }

        public async Task<IActionResult> EnterToBooth(int boothId)
        {
          var dto=await  _allProductsByBoothIdService.Execute(boothId);
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
              IsActive = p.IsActive
          }).ToList();
          ViewBag.Message = TempData["AddToCartBasePrice"];
            return View(model);

        }
    }

   
}
