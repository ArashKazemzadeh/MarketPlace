using Application.Dtos;
using Domin.IRepositories.Dtos.Seller;

namespace Application.IServices.SellerServices.ProfileServices.Queries;

public interface IGetFinancialBySellerId
{
    Task<GeneralDto<FinancialRepSeller>> Execute(int sellerId);
}