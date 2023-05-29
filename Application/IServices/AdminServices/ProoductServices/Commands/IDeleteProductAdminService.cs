

using Application.Dtos;


namespace Application.IServices.AdminServices.ProoductServices.Commands
{
    public interface IDeleteProductAdminService
    {
       Task< GeneralDto> Execute(int id);

    }
}
