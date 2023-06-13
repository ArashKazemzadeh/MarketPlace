namespace WebSite.EndPoint.Areas.Seller.Models
{
    public class AuctionGetVM
    {
        public int Id { get; set; }
        public DateTime? StartDeadTime { get; set; }
        public DateTime? EndDeadTime { get; set; }
        public int HighestPrice { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
