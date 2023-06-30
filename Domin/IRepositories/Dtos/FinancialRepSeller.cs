using ConsoleApp1.Models;

namespace Application.Services.SellerServices.ProfileServices.Queries;

public class FinancialRepSeller
{
    public int Id { get; set; }
    public double CommissionPercentage { get; set; }
    public int? CommissionsAmount { get; set; }
    public int? SalesAmount { get; set; }
    public ICollection<Medal>? Medals { get; set; } 

}