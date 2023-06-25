using Application.Dtos.UserDto;
using Application.IServices.AdminServices.UserService.Commands;
using Domin.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.AdminServices.UserServices.AllUserService
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountService(UserManager<User> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            SignInManager<User> signInManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GetLoggedInUserId()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var userId = await _userManager.GetUserIdAsync(user);
            return userId;
        }
       

        public async Task<int> FindUserIdByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            
            return user.Id;
        }
        public async Task<UserDto> FindUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userDto = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email
            };
            return userDto;
        }

        public async Task<string> UpdateUserAsync(UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id.ToString());
            if (user == null)
            {
                return "کاربر یافت نشد";
            }

            user.Id = userDto.Id;
            user.FullName = userDto.FullName;
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
         var security =   await _userManager.UpdateSecurityStampAsync(user);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return "ویرایش موفقیت آمیز بود";
            }
            else
            {
                return "ویرایش با شکست مواجه شد";
            }
        }

        public async Task<string> UpdatePasswordAsync(string userId , string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return "کاربر یافت نشد";
            }

            var passwordCorrect = await _userManager.CheckPasswordAsync(user, currentPassword);
            if (!passwordCorrect)
                return "رمز عبور فعلی نادرست است.";
            

            // تغییر رمز عبور کاربر
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (result.Succeeded)
                return "گذرواژه تغییر کرد";
            return "تغییر گذرواژه با خطا مواجه شد.";
        }

        public async Task<string> DeleteUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return "کاربر با موفقیت حذف شد";
                }
                return "عملیات با خطا مواجه شد.";
            }

            return "کاربرموجود نیست.";

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
        public async Task AssignUserToRoleByUserId(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, roleName);
        }
        public async Task<User> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            
            return user;
        }
        public async Task<List<string>> GetAllRoles()
        {
            var roles = _roleManager.Roles.Select(r => r.Name).ToList();

            return roles;
        }
        public async Task<List<UserDto>> FindUsersByRole(string roleName)
        {
            var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
            var userNames = usersInRole.Select(user => new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.Email,
                FullName = user.FullName
            }).ToList();
            return userNames;
        }
        public async Task<SignInResult> SignInUserAsync(User user,
            string password, bool isPersistent, bool lockoutOnFailure)
        {
            var result = await _signInManager.PasswordSignInAsync(user,
                password, isPersistent, lockoutOnFailure);
            return result;
        }

        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

