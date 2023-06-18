
using Domin.IRepositories.Dtos;

namespace Application.IServices.CustomerServices.SellerServices.Queries
{
    public interface IGetBoothsByCategoryId
    {
        Task<List<BoothRepositoryDto>> Execute(int categoryId);

    }
}
