using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.AdminServices.UserService.Queries;
using Application.Services.AdminServices.UserServices.Queries;
using ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Admin.Models;

namespace WebSite.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellerController : Controller
    {
        private readonly IDeleteSellerByIdAdminService _deleteSellerByIdAdminService;
        private readonly IGetAllSellerAdminService _getAllSellerService;
        private readonly IUpdateSellerAdminService _updateSellerAdminService;
        private readonly IGetSellerByIdAdminService _getSellerByIdAdmin;
        public SellerController(IGetAllSellerAdminService getAllSellerService,
            IDeleteSellerByIdAdminService deleteSellerByIdAdminService,
            IUpdateSellerAdminService updateSellerAdminService,
            IGetSellerByIdAdminService getSellerByIdAdmin)
        {
            _updateSellerAdminService = updateSellerAdminService;
            _deleteSellerByIdAdminService = deleteSellerByIdAdminService;
            _getAllSellerService = getAllSellerService;
            _getSellerByIdAdmin = getSellerByIdAdmin;
        }
        public async Task<IActionResult> Index()
        {
            var Sellers = await _getAllSellerService.Execute();
            return View(Sellers);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _deleteSellerByIdAdminService.Execute(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
         var result=await   _getSellerByIdAdmin.Execute(id);
         var seller = new SellerVm
         {
             Id = result.Data.Id,
             CompanyName=result.Data.CompanyName,
             IsRemoved = result.Data.IsRemoved,
             IsActive = result.Data.IsActive,
             CommissionPercentage=result.Data.CommissionPercentage
         };
            return View(seller);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SellerVm model)
        {
            var Updatedsellelr = new SellerDto
            {
                Id = model.Id,
                CompanyName = model.CompanyName,
                IsActive = model.IsActive,
                IsRemoved = model.IsRemoved,
                CommissionPercentage = model.CommissionPercentage
            };
      var result=await _updateSellerAdminService.Execute(Updatedsellelr);
            return RedirectToAction("Index");
        }
    }
}
