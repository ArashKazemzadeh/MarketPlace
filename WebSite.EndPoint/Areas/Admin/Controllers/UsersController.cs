using Application.Dtos.UserDto;
using Application.IServices.AdminServices.UserService.Commands;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Admin.Models;

namespace WebSite.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IIdentityRoleService _identityRoleService;

        public UsersController(IAccountService accountService,
            IIdentityRoleService identityRoleService)
        {
            _accountService = accountService;
            _identityRoleService = identityRoleService;
        }
        // GET: UsersController
        public async Task<IActionResult>  Index(string role)
        {
            if (TempData.ContainsKey("role"))
            {
                if (role==null)
                {
                    role = TempData["role"].ToString();
                }
               
            }
            var userExists= await _accountService.FindUsersByRole(role);
         var model=   userExists.Select(u => new UserVM
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                FullName = u.FullName,
                Roles =  _identityRoleService.GetUserRolesAsync(u.Id.ToString()).Result
            }).ToList();
            TempData["role"] = role;
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            //var user=await    _accountService.FindUserByEmailAsync(email);

          var user=await    _accountService.FindUserByIdAsync(id.ToString());
            var model = new UserVM
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            UserName = user.UserName
        };
           return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserVM model)
        {
            var userDto = new UserDto
            {
                Id = model.Id,
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email
            };
            var user = await _accountService.UpdateUserAsync(userDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string email)
        {
            var user = await _accountService.DeleteUserAsync(email);
            return RedirectToAction("Index");
        }
    }
}
