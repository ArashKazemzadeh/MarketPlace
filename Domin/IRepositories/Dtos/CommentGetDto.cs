using ConsoleApp1.Models;

namespace Domin.IRepositories.Dtos;

public class CommentGetDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool? IsConfirm { get; set; }  
    public string? Description { get; set; }
    public DateTime? RegisterDate { get; set; } 
    public int? ProductId { get; set; }
    public virtual Product? Product { get; set; }
    public int CustomertId { get; set; }
    public virtual Customer? Customer { get; set; }
}