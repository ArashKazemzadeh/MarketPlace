namespace Application.IServices.AdminServices.UserService.Commands;

public interface IIdentityRoleService
{
    Task<bool> AddUserToRoleAsync(string userId, string role);
    Task<bool> RemoveUserFromRoleAsync(string userId, string role);
    Task<List<string>> GetUserRolesAsync(string userId);
    Task<bool> CreateRoleAsync(string roleName);
}