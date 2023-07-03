using Domin.IRepositories.Dtos.Seller;

namespace Application.IServices.SellerServices.ProfileServices.Commands;

public interface IAddSellerService
{
    Task<string> Execute(AddSellerDto addSellerDto);
}