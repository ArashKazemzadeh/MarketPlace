using ConsoleApp1.Models;

namespace WebSite.EndPoint.Areas.Seller.Models;

public class ProductSellerVm
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public int? BasePrice { get; set; }
    public bool IsAuction { get; set; }
    public bool? IsConfirm { get; set; }
    public int? Availability { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public List<string> ImagedUrls { get; set; }
    public ICollection<Category> Categories { get; set; }
}