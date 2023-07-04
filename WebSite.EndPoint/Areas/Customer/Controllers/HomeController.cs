using Application.Dtos.UserDto;
using Application.IServices.AdminServices.UserService.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Admin.Models;
using WebSite.EndPoint.Areas.Customer.Models;
using WebSite.EndPoint.Models.ViewModels.Users;

namespace WebSite.EndPoint.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;   
        }
        public async Task<IActionResult> Detail()
        {
            var userId = await _accountService.GetLoggedInUserId();
            var user = await _accountService.FindUserByIdAsync(userId);
            var model = new UserVM
            {
                Id = Convert.ToInt32(userId),
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName
            };
            return View(model);
        }
        public async Task<IActionResult> UpdateUserPassWord()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUserPassWord(PasswordUpdateVM model)
        {
            var userId = await _accountService.GetLoggedInUserId();
            var result = await _accountService.UpdatePasswordAsync(userId, model.currentPassword, model.newPassword);
            ViewBag.Message = result;
            return View();
        }
        public async Task<IActionResult> UpdateUser()
        {
            var userId = await _accountService.GetLoggedInUserId();
            var model = await _accountService.FindUserByIdAsync(userId);
            var sendId = new UserUpdateVM
            {
                Id = Convert.ToInt32(userId),
                Email = model.Email,
                UserName = model.UserName,
            };
            return View(sendId);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateVM model)
        {
         
            var dto = new UserDto
            {
                Id = model.Id,
                Email = model.Email,
                UserName = model.UserName,
                FullName = $"{model.FirstName} {model.LastName}"
            };
            var update = await _accountService.UpdateUserAsync(dto);
            ViewBag.Message = update;
            return RedirectToAction("Detail");
        }
    }
}
