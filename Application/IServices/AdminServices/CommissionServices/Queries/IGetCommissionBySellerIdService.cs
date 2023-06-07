using Application.Dtos;

namespace Application.IServices.AdminServices.CommissionServices.Queries
{
    public interface IGetCommissionBySellerIdService
    {
        Task<GeneralDto> Execute(int id);

    }
}
