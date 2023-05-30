using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.AdminServices.ProoductServices.Queries
{    /// <summary>
///  لیست کالاهایی که در انتظار تایید هستند یا تایید نشده اند را نمایش میدهد
/// </summary>
    public interface IGetProductsWithSellerNameAsyncService
    {
        Task<List<ProductDto>> Execute();
        Task<List<ProductDto>> ExecuteAll();
    }
}
