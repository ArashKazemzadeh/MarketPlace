namespace Application.IServices.SellerServices.CategoryService;

public interface IAddProductToCategoryService
{
    Task<string> Execute(int productId, int categoryId);
}