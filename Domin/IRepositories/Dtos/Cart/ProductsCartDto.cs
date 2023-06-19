

namespace Domin.IRepositories.Dtos.Cart;


public class ProductsCartDto
{
    public int? CartId { get; set; }
    public int ProductId { get; set; }
    public int? Quantity { get; set; }
}
