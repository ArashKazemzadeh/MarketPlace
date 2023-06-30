using Domin.Attributes;

namespace ConsoleApp1.Models;
[Auditable]
public class Seller
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsRemoved { get; set; } = false;
    public double CommissionPercentage { get; set; }
    public int? CommissionsAmount { get; set; }
    public int? SalesAmount { get; set; }
    public Address? Address { get; set; }
    public virtual Booth? Booth { get; set; }
    public virtual Image? Image { get; set; }
    public virtual ICollection<File>? Files { get; set; } = new List<File>();
    public virtual ICollection<Medal>? Medals { get; set; } = new List<Medal>();
    public virtual ICollection<Cart>? Carts { get; set; } = new List<Cart>();
}
