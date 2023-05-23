
using Domin.Entitiess.Users;

namespace Application.IServices.AdminServices.CommissionServices.Queries
{
    public interface IGetCommissionBySellerIdService
    {
        List<AdminDto> Execute(int id);

    }
}
