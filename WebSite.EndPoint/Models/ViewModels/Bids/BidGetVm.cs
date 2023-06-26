namespace WebSite.EndPoint.Models.ViewModels.Bids;

public class BidGetVm
{
    public int Id { get; set; }
    public int? Price { get; set; }
    public DateTime? RegisterDate { get; set; }
    public bool? IsAccepted { get; set; }
    public int? AuctionId { get; set; }
    public string ProductName { get; set; }
    public DateTime? EndDateAuction { get; set; }
    public DateTime? StartDateAuction { get; set; }
}