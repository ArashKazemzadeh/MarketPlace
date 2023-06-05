using Domin.Entities.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.IServices.CustomerServices.UserService.Commands
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AccountService(UserManager<User> userManager,
            RoleManager<IdentityRole<int>> roleManager, 
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<int> FindUserIdByEmailAsync(string email)
        {
           var user=await _userManager.FindByEmailAsync(email);
           return user.Id;
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterDto model)
        {
            var newUser = new User
            {
                Email = model.Email,
                UserName = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            return result;
        }

        public async Task<string> CreateRoleIfNotExists(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new IdentityRole<int>(roleName);
                await _roleManager.CreateAsync(role);
                return "نقش جدید ایجاد شد";
            }
            return "نقش موجود است";
        }
        public async Task AssignUserToRole(string userEmail, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            await _userManager.AddToRoleAsync(user, roleName);
        }
        public async Task<User> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<SignInResult> SignInUserAsync(User user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
            return result;
          }

        public async Task SignOutUserAsync()
        {
               await _signInManager.SignOutAsync();
        }
    }
    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDto model);
        Task<string> CreateRoleIfNotExists(string roleName);
        Task AssignUserToRole(string userEmail, string roleName);
        Task<int> FindUserIdByEmailAsync(string email);
        Task<User> FindUserByEmailAsync(string email);
        Task<SignInResult> SignInUserAsync(User user, string password, bool isPersistent, bool lockoutOnFailure);
        Task SignOutUserAsync();
    }

    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
