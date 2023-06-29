using Domin.Attributes;

namespace ConsoleApp1.Models;
[Auditable]

public class File
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public string? Name { get; set; }

    public int? SellerId { get; set; }

    public virtual Seller? Seller { get; set; }
}
