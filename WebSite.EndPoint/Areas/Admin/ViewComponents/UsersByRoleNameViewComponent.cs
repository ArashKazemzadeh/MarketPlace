using Application.IServices.AdminServices.UserService.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Admin.ViewComponents
{
    public class UsersByRoleNameViewComponent : ViewComponent
    {
        private readonly IAccountService _accountService;

        public UsersByRoleNameViewComponent(IAccountService accountService)
        {
            _accountService = accountService;   
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
        var roles=await    _accountService.GetAllRoles();
            return View(roles);
        }
    }
}

