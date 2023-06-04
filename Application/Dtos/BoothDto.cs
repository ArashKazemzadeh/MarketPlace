
using ConsoleApp1.Models;

namespace ConsoleApp.Models;


public class BoothDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    public int? SellerId { get; set; }
    public string? Seller { get; set; }

}
