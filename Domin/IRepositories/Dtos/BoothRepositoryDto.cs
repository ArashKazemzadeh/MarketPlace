using ConsoleApp1.Models;

namespace Domin.IRepositories.Dtos;

public class BoothRepositoryDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? SellerId { get; set; }
    public Seller? Seller { get; set; }
    public string? SellerName { get; set; }
}