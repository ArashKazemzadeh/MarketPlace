using ConsoleApp1.Models;

namespace WebSite.EndPoint.Models.ViewModels;

public class GetCommentVM
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? RegisterDate { get; set; }
    public string ProductName  { get; set; }
    public string UserId { get; set; }
 

}