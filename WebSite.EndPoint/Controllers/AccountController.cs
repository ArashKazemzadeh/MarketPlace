using Application.Dtos.UserDto;
using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.SellerServices.ProfileServices.Commands;
using Domin.IRepositories.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Seller.Models;
using WebSite.EndPoint.Models.ViewModels.Users;
using WebSite.EndPoint.Utilities.Filters;

namespace WebSite.EndPoint.Controllers
{
    
    [ServiceFilter(typeof(SaveVisitorFilter))]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAddUserIdToCustomerForRegisterService _addUserIdToCustomerForRegisterService;
        private readonly IAddSellerService _addSellerService;
        public AccountController(IAccountService accountService,
              IAddUserIdToCustomerForRegisterService addUserIdToCustomerForRegisterService,
              IAddSellerService addSellerService)
        {

            _accountService = accountService;
            _addUserIdToCustomerForRegisterService = addUserIdToCustomerForRegisterService;
            _addSellerService = addSellerService;
        }
        public async Task<IActionResult>  RegisterSeller()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  RegisterSeller(BoothSellerVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId =await _accountService.GetLoggedInUserId();
            if (userId==null)
            {
                ViewBag.Message = "نام کاربری یافت نشد. لطفا  از سیستم خارج شوید و دوباره وارد شوید.";
                return View(model);
            }
            var newrole = "Seller";
            await _accountService.CreateRoleIfNotExists(newrole);
            await _accountService.AssignUserToRoleByUserId(userId, newrole);
            var addSellerDto = new AddSellerDto
            {
                SellerId =Convert.ToInt32(userId) ,
                CompanyName=model.CompanyName,
                City = model.City,
                Street = model.Street,
                AddressDescription = model.AddressDescription,
                BoothName = model.BoothName,
                BoothDescription = model.BoothDescription
            };
         var result =   await _addSellerService.Execute(addSellerDto);
            return Redirect("/seller/home/index");
        }
        public async Task<IActionResult> Register()
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
                var newrole = "Customer";
                // Create user role, assign role to user and do other necessary steps
                var userId = await _accountService.FindUserIdByEmailAsync(model.Email);
                await _accountService.CreateRoleIfNotExists(newrole);
                await _accountService.AssignUserToRole(model.Email, newrole);
                var newCustomer = new CustomerDto
                {
                    Id = userId
                };
             await   _addUserIdToCustomerForRegisterService.Execute(newCustomer);
                var user = await _accountService.FindUserByEmailAsync(model.Email);
                await _accountService.SignInUserAsync(user, model.Password, true, true);
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
