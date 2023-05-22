using Domin.Attributes;

namespace ConsoleApp1.Models;
[Auditable]

public class Seller
{
    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string LastName { get; set; } = null!;

    public string? CompanyName { get; set; }

    public bool IsActive { get; set; }
    public double CommissionPercentage { get; set; }

    public int? CommissionsAmount { get; set; }

    public int? SalesAmount { get; set; }
    public Address? Address { get; set; }

    public virtual Booth? Booth { get; set; }

    public virtual ICollection<FileForUser> Files { get; set; } = new List<FileForUser>();

    public virtual ICollection<Medal> Medals { get; set; } = new List<Medal>();
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
