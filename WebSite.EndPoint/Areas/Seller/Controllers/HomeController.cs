using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.SellerServices.ImageServices.Commands;
using Application.IServices.SellerServices.ProfileServices.Commands;
using Application.IServices.SellerServices.ProfileServices.Queries;
using Application.IServices.Visitors;
using Application.Services.AdminServices.UserServices.SellerService.Queries;
using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.Seller;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Seller.Models;

namespace WebSite.EndPoint.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class HomeController : Controller
    {

        private readonly IUpdateSellerByIdService _updateSellerByIdService;
        private readonly IGetSellerByIdService _getSellerByIdService;
        private readonly IAccountService _accountService;
        private readonly IProductImageQueriesService _imageQueriesService;
        private readonly IConfiguration _configuration;

        public HomeController(
            IUpdateSellerByIdService updateSellerByIdService,
            IAccountService accountService,
            IGetSellerByIdService getSellerByIdService,
            IProductImageQueriesService imageQueriesService, 
            IConfiguration configuration
            )
        {
            _updateSellerByIdService = updateSellerByIdService;
            _accountService = accountService;
            _getSellerByIdService = getSellerByIdService;
            _imageQueriesService = imageQueriesService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var sellerStringId = await _accountService.GetLoggedInUserId();
            if (sellerStringId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var result = await _imageQueriesService.GetAllImageProductBySellerId(int.Parse(sellerStringId));
            return View(result);
        }
        public async Task<IActionResult> EditProfile()
        {
            var sellerId = Convert.ToInt32(await _accountService.GetLoggedInUserId());
            var seller = await _getSellerByIdService.Execute(sellerId);
            var cities = _configuration.GetSection("Cities").Get<string[]>();
            ViewBag.Cities = cities;
            var model = new BoothSellerVM
            {
                SellerId = seller.SellerId,
                CompanyName = seller.CompanyName,
                City = seller.City,
                Street = seller.Street,
                AddressDescription = seller.AddressDescription,
                BoothName = seller.BoothName,
                BoothDescription = seller.BoothDescription,
                BoothId = seller.BoothId,
                AddressId = seller.AddressId
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(BoothSellerVM seller, string selectedCity)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(seller);
            //}
            var updatedSeller = new AddSellerDto
            {
                SellerId = seller.SellerId,//
                CompanyName = seller.CompanyName,
                City = selectedCity,
                Street = seller.Street,
                AddressDescription = seller.AddressDescription,
                BoothName = seller.BoothName,
                BoothDescription = seller.BoothDescription,
                BoothId = seller.BoothId,//
                AddressId = seller.AddressId//
            };
            var result = await _updateSellerByIdService.Execute(updatedSeller);
            if (result)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Message = "فروشنده موجود نیست";
            return View(seller);

        }
    }
}
