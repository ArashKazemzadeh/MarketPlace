using ConsoleApp1.Models;

namespace ConsoleApp.Models;
public class AuctionDto
{
    public int Id { get; set; }
    public DateTime? StartDeadTime { get; set; }
    public DateTime? EndDeadTime { get; set; }
    public int HighestPrice { get; set; }
    public int ProductId { get; set; }
    public  Product Product { get; set; }
    //public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
}

