using Microsoft.AspNetCore.Identity;
using Domin.Entities.Users;
using Application.IServices.AdminServices.UserService.Commands;

namespace Application.Services.AdminServices.UserServices.AllUserService
{
    public class IdentityRoleService: IIdentityRoleService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public IdentityRoleService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<bool> AddUserToRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false; // کاربر یافت نشد
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }
       
        public async Task<bool> RemoveUserFromRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false; // کاربر یافت نشد
            }

            var result = await _userManager.RemoveFromRoleAsync(user, role);
            return result.Succeeded;
        }

        public async Task<List<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null; // کاربر یافت نشد
            }

            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
            {
                return false; // نقش قبلاً وجود دارد
            }

            var role = new IdentityRole<int>(roleName);
            var result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }
    }

}
