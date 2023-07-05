using Domin.Attributes;


namespace ConsoleApp1.Models;
[Auditable]

public class Booth
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    public bool IsRemoved { get; set; } = false;

    public int? SellerId { get; set; }
    public Seller? Seller { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
