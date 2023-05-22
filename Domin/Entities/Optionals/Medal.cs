using Domin.Attributes;

namespace ConsoleApp1.Models;
[Auditable]

public class Medal
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public int? SellerId { get; set; }
    public string? Description { get; set; }
    public virtual Seller? Seller { get; set; }
}
