using Domin.IRepositories.Dtos.Booth;

namespace Application.IServices.CustomerServices.SellerServices.Queries
{
    public interface IGetBoothsByCategoryId
    {
        Task<List<BoothRepositoryDto>> Execute(int categoryId);

    }
}
