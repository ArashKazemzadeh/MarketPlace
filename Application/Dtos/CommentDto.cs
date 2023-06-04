
namespace ConsoleApp.Models;

public  class CommentDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? RegisterDate { get; set; }
    public string? SellerName { get; set; }
    public string ProductName { get; set; }
    public string CustomerName { get; set; }
}


