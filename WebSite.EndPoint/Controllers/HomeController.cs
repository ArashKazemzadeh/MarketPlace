using Application.IServices.CustomerServices.ProductServices.Queries;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Models.ViewModels;
using WebSite.EndPoint.Utilities.Filters;


namespace WebSite.EndPoint.Controllers
{
    [ServiceFilter(typeof(SaveVisitorFilter))]
    
    public class HomeController : Controller
    {
        private readonly IGetLatestProductsService _getLatestProductsService;

        public HomeController(IGetLatestProductsService getLatestProductsService)
        {
            _getLatestProductsService = getLatestProductsService;
        }

        public async Task<IActionResult>  Index()
        {
            var products= await _getLatestProductsService.Execute();
            var model = products.Select(p => new ProductGetVM
            {
                Id = p.Id,
                Name = p.Name,
                BasePrice = p.BasePrice,
                ImageUrl = p.ImageUrl,
                BoothId = p.BoothId
            }).ToList();
            return View(model);
        }
        public async Task<IActionResult> Error()
        {
            ViewBag.Error = TempData["Error"];
            return View();
        }

    }
}