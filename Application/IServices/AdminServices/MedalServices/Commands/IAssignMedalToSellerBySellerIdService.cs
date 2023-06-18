using Application.Dtos;


namespace Application.IServices.AdminServices.MedalServices.Commands
{

    /// <summary>
    /// اختصاص مدال به فروشنده بر اساس شناسه
    /// </summary>
    public interface IAssignMedalToSellerBySellerIdService
    {
       Task< GeneralDto> Execute(int id);

    }
}
