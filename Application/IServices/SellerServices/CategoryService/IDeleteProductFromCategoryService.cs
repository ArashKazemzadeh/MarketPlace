namespace Application.IServices.SellerServices.CategoryService;

public interface IDeleteProductFromCategoryService
{
    Task<string> Execute(int productId, int categoryId);
}