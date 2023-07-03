using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Bid;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface ICustomerRepository
{
    Task<int> UpdateWithBidAsync(Customer customer, BidRepDto bidDto);
    Task<Customer> GetByIdAsync(int id);
    Task<List<Customer>> GetAllAsync();
    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(Customer customer);
}