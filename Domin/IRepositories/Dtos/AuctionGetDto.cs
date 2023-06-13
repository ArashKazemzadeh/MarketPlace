

namespace Domin.IRepositories.Dtos
{
    public class AuctionGetDto
    {
        public int Id { get; set; }
        public DateTime? StartDeadTime { get; set; }
        public DateTime? EndDeadTime { get; set; }
        public int HighestPrice { get; set; }
        //public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        //public virtual Product Product { get; set; } = null!;
    }
}
