using Domin.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models;
[Auditable]

public class ProductsCart
{

    public int CartId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
