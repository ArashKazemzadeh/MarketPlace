using Domin.Entities.Users;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface IUserRepository
{
    Task<List<User>> GetUsersByCustomerIdsAsync(List<int> customerIds);
    Task<User> GetUserByCustomerIdAsync(int customerId);
}