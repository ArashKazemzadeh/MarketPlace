
using Application.Dtos;
using Domin.Entitiess.Users;

namespace Application.IServices.AdminServices.CommissionServices.Queries
{
    public interface IGetCommissionBySellerIdService
    {
        Task<GeneralDto> Execute(int id);

    }
}
