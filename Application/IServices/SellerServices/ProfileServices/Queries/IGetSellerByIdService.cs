using Domin.IRepositories.Dtos;

namespace Application.IServices.SellerServices.ProfileServices.Queries;

public interface IGetSellerByIdService
{
    Task<AddSellerDto> Execute(int sellerId);
}