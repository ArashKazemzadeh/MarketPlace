namespace ConsoleApp.Models;
public class SellerDto
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? CompanyName { get; set; }
    public bool IsActive { get; set; }
    public bool IsRemoved { get; set; }
    public double CommissionPercentage { get; set; }
    public int? CommissionsAmount { get; set; }
    public int? SalesAmount { get; set; }
}
