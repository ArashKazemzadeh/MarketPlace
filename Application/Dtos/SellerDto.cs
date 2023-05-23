

namespace ConsoleApp.Models;


public class SellerDto
{
    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string LastName { get; set; } = null!;

    public string? CompanyName { get; set; }

    public bool IsActive { get; set; }
    public double CommissionPercentage { get; set; }

    public int? CommissionsAmount { get; set; }

    public int? SalesAmount { get; set; }
   

  
   
}
