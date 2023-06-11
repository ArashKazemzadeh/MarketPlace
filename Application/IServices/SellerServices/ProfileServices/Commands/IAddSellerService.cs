using Domin.IRepositories.Dtos;

namespace Application.IServices.SellerServices.ProfileServices.Commands;

public interface IAddSellerService
{
    Task<string> Execute(AddSellerDto addSellerDto);
}