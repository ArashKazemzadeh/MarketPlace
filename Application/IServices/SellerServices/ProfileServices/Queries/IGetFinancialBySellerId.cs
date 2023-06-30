using Application.Dtos;
using Application.Services.SellerServices.ProfileServices.Queries;

namespace Application.IServices.SellerServices.ProfileServices.Queries;

public interface IGetFinancialBySellerId
{
    Task<GeneralDto<FinancialRepSeller>> Execute(int sellerId);
}