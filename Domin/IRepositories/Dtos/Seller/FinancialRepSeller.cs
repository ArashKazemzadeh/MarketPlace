using ConsoleApp1.Models;

namespace Domin.IRepositories.Dtos.Seller;

public class FinancialRepSeller
{
    public int Id { get; set; }
    public double CommissionPercentage { get; set; }
    public int? CommissionsAmount { get; set; }
    public int? SalesAmount { get; set; }
    public ICollection<Medal>? Medals { get; set; }

}