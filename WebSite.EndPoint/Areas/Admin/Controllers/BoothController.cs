using Application.IServices.AdminServices.BoothServices.Commands;
using Application.IServices.AdminServices.BoothServices.Queries;
using ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BoothController : Controller
    {
        private readonly IGetAllBoothAdminService _allBoothAdminService;
        private readonly IGetBoothByIdService       _getBoothByIdService;
        private readonly IDeleteBoothAdminService   _deleteBoothAdminService;
        private readonly IUpdateBoothAdminService _updateBoothAdminService;
        public BoothController(IGetAllBoothAdminService allBoothAdminService,
            IGetBoothByIdService getBoothByIdService,
            IDeleteBoothAdminService deleteBoothAdminService,
            IUpdateBoothAdminService updateBoothAdminService)
        {
            _allBoothAdminService = allBoothAdminService;
            _getBoothByIdService = getBoothByIdService;
            _deleteBoothAdminService = deleteBoothAdminService;
            _updateBoothAdminService = updateBoothAdminService;
        }
        public async Task< IActionResult> Index()
        {
           var booths=await _allBoothAdminService.Execute();
            return View(booths);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var booths = await _deleteBoothAdminService.Execute(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var booth = await _getBoothByIdService.Execute(id);
            return View(booth.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BoothDto model)
        {
           var result=await    _updateBoothAdminService.Execute(model);
            return RedirectToAction("Index");
        }
    }
}
