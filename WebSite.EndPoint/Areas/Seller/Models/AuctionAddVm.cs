namespace WebSite.EndPoint.Areas.Seller.Models
{
    public class AuctionAddVm
    {
        public DateTime? StartDeadTime { get; set; }
        public DateTime? EndDeadTime { get; set; }
        public int ProductId { get; set; }
    }
}
