using Domin.Entities.Users;

namespace Persistence.Repositories.Users;

public interface IUserRepository
{
    Task<List<User>> GetUsersByCustomerIdsAsync(List<int> customerIds);
    Task<User> GetUserByCustomerIdAsync(int customerId);
}