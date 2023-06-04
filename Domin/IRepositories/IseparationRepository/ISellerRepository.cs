using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;

namespace Domin.IRepositories.IseparationRepository;

public interface ISellerRepository
{
    Task<Seller> GetByIdAsync(int id);
    Task<List<Seller>> GetAllAsync();
    Task AddAsync(Seller seller);
    Task<bool> UpdateAsync(SellerUpdateRepositoryDto seller);
    Task DeleteAsync(int seller);
}