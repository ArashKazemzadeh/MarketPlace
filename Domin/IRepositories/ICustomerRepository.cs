using ConsoleApp1.Models;

namespace Persistence.Repositories.Users;

public interface ICustomerRepository
{
    Task<Customer> GetByIdAsync(int id);
    Task<List<Customer>> GetAllAsync();
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(Customer customer);
}