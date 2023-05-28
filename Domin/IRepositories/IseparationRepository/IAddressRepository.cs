using ConsoleApp1.Models;

namespace Domin.IRepositories.IseparationRepository;

public interface IAddressRepository
{
    Task<Address> GetByIdAsync(int id);
    Task<List<Address>> GetAllAsync();
    Task AddAsync(Address address);
    Task UpdateAsync(Address address);
    Task DeleteAsync(Address address);
}