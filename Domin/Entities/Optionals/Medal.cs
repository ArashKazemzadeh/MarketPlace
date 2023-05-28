using Domin.Attributes;
using Domin.Enums;

namespace ConsoleApp1.Models;
[Auditable]

public class Medal
{
    public int Id { get; set; }
    public MedalEnum? Type { get; set; }
    public int? SellerId { get; set; }
    public virtual Seller? Seller { get; set; }
}
