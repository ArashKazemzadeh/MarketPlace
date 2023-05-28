using ConsoleApp1.Models;

namespace Domin.IRepositories.IseparationRepository;

public interface IInvoiceRepository
{
    Task<Invoice> GetByIdAsync(int id);
    Task<List<Invoice>> GetAllAsync();
    Task AddAsync(Invoice invoice);
    Task UpdateAsync(Invoice invoice);
    Task DeleteAsync(Invoice invoice);
}