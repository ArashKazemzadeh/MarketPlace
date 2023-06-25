using Application.Dtos.UserDto;
using Domin.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace Application.IServices.AdminServices.UserService.Commands;

public interface IAccountService
{
    Task<string> UpdatePasswordAsync(string userId, string currentPassword, string newPassword);
    Task AssignUserToRoleByUserId(string userId, string roleName);
    Task<string> GetLoggedInUserId();
    Task<string> UpdateUserAsync(UserDto userDto);
    Task<UserDto> FindUserByIdAsync(string id);
    Task<string> DeleteUserAsync(string email);
    Task<List<string>> GetAllRoles();
    Task<List<UserDto>> FindUsersByRole(string roleName);
    Task<IdentityResult> CreateUserAsync(RegisterDto model);
    Task<string> CreateRoleIfNotExists(string roleName);
    Task AssignUserToRole(string userEmail, string roleName);
    Task<int> FindUserIdByEmailAsync(string email);
    Task<User> FindUserByEmailAsync(string email);
    Task<SignInResult> SignInUserAsync(User user, string password, bool isPersistent, bool lockoutOnFailure);
    Task SignOutUserAsync();
}