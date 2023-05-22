using Domin.Attributes;

namespace ConsoleApp1.Models;
[Auditable]

public class Auction
{
    public int Id { get; set; }
    public DateTime? StartDeadTime { get; set; }
    public DateTime? EndDeadTime { get; set; }
    public int HighestPrice { get; set; }
    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}
