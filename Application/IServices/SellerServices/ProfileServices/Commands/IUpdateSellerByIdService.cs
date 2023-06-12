

using Domin.IRepositories.Dtos;

namespace Application.IServices.SellerServices.ProfileServices.Commands
{
    public interface IUpdateSellerByIdService
    {
      Task<bool> Execute(AddSellerDto updateellerDto);

    }
}
