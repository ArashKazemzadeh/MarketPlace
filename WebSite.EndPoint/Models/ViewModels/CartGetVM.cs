namespace WebSite.EndPoint.Models.ViewModels;

public class CartGetVM
{
    public int Id { get; set; }
    public int? TotalPrices { get; set; }
    public int? CustomerId { get; set; }
    public bool IsRegistrationFinalized { get; set; }
    public string? BoothName { get; set; }
    public int boothId { get; set; }
    public List<string> ProductsNames { get; set; }
}