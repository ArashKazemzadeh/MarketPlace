using Domin.IRepositories.Dtos.Seller;

namespace Domin.IRepositories.IseparationRepository.Dapper
{
    public interface IUserDapperRepository
    {
        Task<FinancialRepSeller> GetFinancialBySellerId(int sellerId);
    }
}
