using Application.IServices.AdminServices.CommissionServices.Queries;
using Application.Services.AdminServices.UserServices.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommissionController : Controller
    {
        //private readonly IGetAllCommissionsService _getAllCommissionsService;
        //private readonly IGetCommissionBySellerIdService _commissionBySellerIdService;
        private readonly IGetAllSellerService _getAllSellerService;
        public CommissionController(IGetAllSellerService getAllSellerService)
        {
            _getAllSellerService = getAllSellerService;
        }
        public async Task<IActionResult> Index()
        {
            var Sellers =await _getAllSellerService.Execute();
            return View(Sellers);
        }
    }
}
