using Application.IServices.CustomerServices.UserService.Commands;
using ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Models.ViewModels.Users;
using WebSite.EndPoint.Utilities.Filters;

namespace WebSite.EndPoint.Controllers
{
    [ServiceFilter(typeof(SaveVisitorFilter))]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAddUserIdToCustomerForRegisterService _addUserIdToCustomerForRegisterService;
        public AccountController(IAccountService accountService,
              IAddUserIdToCustomerForRegisterService addUserIdToCustomerForRegisterService)
        {

            _accountService = accountService;
            _addUserIdToCustomerForRegisterService = addUserIdToCustomerForRegisterService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userdto = new RegisterDto()
            {
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password
            };
            var result = await _accountService.CreateUserAsync(userdto);

            if (result.Succeeded)
            {
                var createRoleResult = await _accountService.CreateRoleIfNotExists("Customer");
                await _accountService.AssignUserToRole(model.Email, "Customer");
                var userId = await _accountService.FindUserIdByEmailAsync(model.Email);
                var newCustomer = new CustomerDto()
                {
                    Id = userId
                };
                _addUserIdToCustomerForRegisterService.Execute(newCustomer);
                return RedirectToAction(nameof(Profile));
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }

            return View(model);
        }
        public IActionResult Profile()
        {
            return View();
        }

        public async Task<IActionResult> Login(string returnUrl = "/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl,
            });
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _accountService.FindUserByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
                return View(model);
            }

            await _accountService.SignOutUserAsync();
            var result = await _accountService.SignInUserAsync(user, model.Password, model.IsPersistent, true);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await _accountService.SignOutUserAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
