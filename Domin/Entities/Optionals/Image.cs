using Domin.Attributes;
namespace ConsoleApp1.Models;


[Auditable]
public class Image
{
    public int Id { get; set; }
    public int? SellerId { get; set; }

    public int? ProductId { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Seller? Seller { get; set; }
    public string? Url { get; set; }
}
