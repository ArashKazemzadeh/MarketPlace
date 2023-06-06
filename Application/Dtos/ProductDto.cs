
namespace ConsoleApp.Models;


public class ProductDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? BasePrice { get; set; }
    public bool IsAuction { get; set; }
    public bool? IsConfirm { get; set; }
    public int? Availability { get; set; }
    public string? Description { get; set; }
    public string? SellerName { get; set; }
    public bool IsActive { get; set; }
    public int? BidId { get; set; }
}
