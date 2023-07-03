using ConsoleApp1.Models;

namespace Domin.IRepositories.Dtos.Product;


public class ProductDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? BasePrice { get; set; }
    public bool IsAuction { get; set; }
    public bool? IsConfirm { get; set; }
    public int? Availability { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public ConsoleApp1.Models.Auction Auction { get; set; }
    public ICollection<ConsoleApp1.Models.Image> Image { get; set; }
    public ICollection<ConsoleApp1.Models.Category> Categories { get; set; }
}

