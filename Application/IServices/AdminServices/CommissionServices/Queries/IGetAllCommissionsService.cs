
using Domin.Entitiess.Users;

namespace Application.IServices.AdminServices.CommissionServices.Queries
{
    public interface IGetAllCommissionsService
    {
        Task<int> Execute();

    }
}
