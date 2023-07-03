using ConsoleApp1.Models;

namespace Domin.IRepositories.Dtos.Comment;

public class CommentGetDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool? IsConfirm { get; set; }
    public string? Description { get; set; }
    public DateTime? RegisterDate { get; set; }
    public int? ProductId { get; set; }
    public ConsoleApp1.Models.Product? Product { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}