using Application.Dtos;


namespace Application.IServices.AdminServices.MedalServices.Commands
{
    public interface IAssignMedalToSellerBySellerIdService
    {
       Task< GeneralDto> Execute(int id);

    }
}
