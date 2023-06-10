using Application.Dtos.ProductDto;

namespace Application.IServices.AdminServices.ProoductServices.Queries
{    /// <summary>
///  لیست کالاهایی که در انتظار تایید هستند  را نمایش میدهد
/// </summary>
    public interface IGetProductsWithSellerNameAsyncService
    {
        Task<List<ProductDto>> Execute();
        Task<List<ProductDto>> ExecuteAll();
    }
}
