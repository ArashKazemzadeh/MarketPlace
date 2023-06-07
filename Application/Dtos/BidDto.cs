namespace ConsoleApp.Models;


public class BidDto
{
    public int Id { get; set; }

    public int? Price { get; set; }
    public DateTime? RegisterDate { get; set; }=DateTime.Now;

  
}
