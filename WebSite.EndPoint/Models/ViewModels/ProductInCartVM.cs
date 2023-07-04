namespace WebSite.EndPoint.Models.ViewModels;

public class ProductInCartVM
{
    public int ProductId { get; set; }
    public int TotalPrice { get; set; }
    public int Quantity { get; set; }
    public int BoothId { get; set; }
    public int CartId { get; set; }
    public string Name { get; set; }
    public int BasePrice { get; set; }
}