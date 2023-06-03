using Domin.Attributes;

namespace ConsoleApp1.Models;
[Auditable]

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? BasePrice { get; set; }
    public bool IsAuction { get; set; } = false;
    public bool IsConfirm { get; set; } = false;
    public int? Availability { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public int? BidId { get; set; }
    public virtual Auction? Auction { get; set; }
    public int? BoothId { get; set; }
    public virtual Booth? Booth { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<ImageForProduct> Images { get; set; } = new List<ImageForProduct>();
    public virtual ICollection<ProductsCart> ProductsCarts { get; set; } = new List<ProductsCart>();
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
