using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.SellerServices.ProfileServices.Commands;
using Application.IServices.SellerServices.ProfileServices.Queries;
using Application.IServices.Visitors;
using Application.Services.AdminServices.UserServices.SellerService.Queries;
using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
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

        private readonly IGetToDayReportService _getTodayReportService;

        public HomeController(
            IUpdateSellerByIdService updateSellerByIdService, 
            IAccountService accountService, 
            IGetSellerByIdService getSellerByIdService, IGetToDayReportService getTodayReportService)
        {
            _updateSellerByIdService = updateSellerByIdService;
            _accountService = accountService;
            _getSellerByIdService = getSellerByIdService;
            _getTodayReportService = getTodayReportService;
        }
        
        public IActionResult Index()
        {
            return View(_getTodayReportService.Execute());
        }
        public async Task<IActionResult>  EditProfile()
        {
            var sellerId = Convert.ToInt32(await _accountService.GetLoggedInUserId());
            var seller =await _getSellerByIdService.Execute(sellerId);
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
        public async Task<IActionResult> EditProfile(BoothSellerVM seller)
        {
            if (!ModelState.IsValid)
            {
                return View(seller);
            }
            var updatedSeller = new AddSellerDto
            {
                SellerId = seller.SellerId,//
                CompanyName = seller.CompanyName,
                City = seller.City,
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
