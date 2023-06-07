

namespace Application.IServices.AdminServices.CommissionServices.Queries
{     
    /// <summary>
    /// محاسبه ی سود کل سایت از ابتدا تا اکنون
    /// </summary>
    public interface IGetAllCommissionsService
    {
        Task<int> Execute();

    }
}
