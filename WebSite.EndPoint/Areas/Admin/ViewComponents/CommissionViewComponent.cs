using Application.IServices.AdminServices.CommissionServices.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Admin.ViewComponents
{
    public class CommissionViewComponent : ViewComponent
    {
        private readonly IGetAllCommissionsService _getAllCommissionsService;

        public CommissionViewComponent(IGetAllCommissionsService getAllCommissionsService)
        {
            _getAllCommissionsService = getAllCommissionsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var perfid = await _getAllCommissionsService.Execute();
            return View(perfid);
        }
    }

}
