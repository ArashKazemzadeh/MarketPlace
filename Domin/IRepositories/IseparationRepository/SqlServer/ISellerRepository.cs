using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Seller;

namespace Domin.IRepositories.IseparationRepository.SqlServer;

public interface ISellerRepository
{
    Task<FinancialRepSeller> GetFinancialBySellerId(int sellerId);
    Task<AddSellerDto> GetByIdWithNavigationAsync(int id);
    Task<Seller> GetByIdAsync(int id);
    Task<List<Seller>> GetAllAsync();
    Task AddAsync(SellerRepDto seller);
    Task<bool> UpdateAsync(SellerUpdateRepositoryDto seller);
    Task<bool> UpdateProfileAsync(AddSellerDto updatesellerDto);
    Task DeleteAsync(int seller);
}