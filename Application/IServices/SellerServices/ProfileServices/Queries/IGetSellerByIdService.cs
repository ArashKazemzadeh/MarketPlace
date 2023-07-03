using Domin.IRepositories.Dtos.Seller;

namespace Application.IServices.SellerServices.ProfileServices.Queries;

public interface IGetSellerByIdService
{
    Task<AddSellerDto> Execute(int sellerId);
}