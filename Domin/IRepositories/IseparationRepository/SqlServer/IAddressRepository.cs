using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface IAddressRepository
{
    Task<Address> GetByIdAsync(int id);
    Task<List<Address>> GetAllAsync();
    Task AddAsync(AddressRepDto address);
    Task UpdateAsync(AddressRepDto addressdto);
    Task DeleteAsync(Address address);
}