using ConsoleApp1.Models;

namespace Application.Dtos.UserDto;
public class SellerDto
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public int? CommissionsAmount { get; set; }
    public int? SalesAmount { get; set; }
    public double CommissionPercentage { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsRemoved { get; set; } = false;
    public Address? Address { get; set; }
    public virtual Booth? Booth { get; set; }
}
