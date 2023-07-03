namespace WebSite.EndPoint.Models.ViewModels;

public class ProductGetVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BasePrice { get; set; }
    public string? ImageUrl { get; set; }
}