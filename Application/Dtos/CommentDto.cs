
namespace ConsoleApp.Models;

public  class CommentDto
{
    public int Id { get; set; }

    public string? Title { get; set; }
   

    public string? Description { get; set; }
    public DateTime? RegisterDate { get; set; }=DateTime.Now;

    public int? ProductId { get; set; }

  
    public int? CustomertId { get; set; }

}