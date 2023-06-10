using Domin.Attributes;


namespace ConsoleApp1.Models;
[Auditable]

public class ImageForProduct
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
