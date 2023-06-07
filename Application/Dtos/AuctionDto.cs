namespace ConsoleApp.Models;
public class AuctionDto
{
    public int Id { get; set; }
    public DateTime? StartDeadTime { get; set; }
    public DateTime? EndDeadTime { get; set; }
    public int HighestPrice { get; set; }
}

