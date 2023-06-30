using Application.Services.SellerServices.ProfileServices.Queries;

namespace Domin.IRepositories.IseparationRepository.Dapper
{
    public interface IUserDapperRepository
    {
        Task<FinancialRepSeller> GetFinancialBySellerId(int sellerId);
    }
}
