using Domin.Attributes;

namespace ConsoleApp1.Models;
[Auditable]

public class FileForUser
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public string? Name { get; set; }

    public byte[] FileData { get; set; } = null!;

    public int? SellerId { get; set; }

    public virtual Seller? Seller { get; set; }
}
