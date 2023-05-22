using ConsoleApp1.Models;

namespace Persistence.Repositories.Optionals;

public interface IAddressRepository
{
    Task<Address> GetByIdAsync(int id);
    Task<List<Address>> GetAllAsync();
    Task AddAsync(Address address);
    Task UpdateAsync(Address address);
    Task DeleteAsync(Address address);
}