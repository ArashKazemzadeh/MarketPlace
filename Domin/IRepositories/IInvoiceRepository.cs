using ConsoleApp1.Models;

namespace Persistence.Repositories.Orders;

public interface IInvoiceRepository
{
    Task<Invoice> GetByIdAsync(int id);
    Task<List<Invoice>> GetAllAsync();
    Task AddAsync(Invoice invoice);
    Task UpdateAsync(Invoice invoice);
    Task DeleteAsync(Invoice invoice);
}