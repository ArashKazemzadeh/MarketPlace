using Domin.Attributes;


namespace ConsoleApp1.Models;
[Auditable]

public class Bid
{
    public int Id { get; set; }

    public int? Price { get; set; }
    public DateTime? RegisterDate { get; set; }=DateTime.Now;

    public bool? IsAccepted { get; set; }

    public int? AuctionId { get; set; }
    public int? CustomerId { get; set; }

    public virtual Auction? Auction { get; set; }

    public virtual Customer? Customer { get; set; }
}
