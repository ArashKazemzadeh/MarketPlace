
namespace ConsoleApp.Models;


public class ProductDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? BasePrice { get; set; }

    public bool InAuction { get; set; }
    public bool ISAccepted { get; set; }


    public int? Availability { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int BidId { get; set; }

   

}
