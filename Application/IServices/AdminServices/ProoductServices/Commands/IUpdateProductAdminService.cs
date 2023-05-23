
using ConsoleApp.Models;

namespace Application.IServices.AdminServices.ProoductServices.Commands
{
    public interface IUpdateProductAdminService
    {
        ProductDto Execute(int id);

    }
}
