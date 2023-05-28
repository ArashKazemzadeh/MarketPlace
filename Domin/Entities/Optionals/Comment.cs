using Domin.Attributes;
using Domin.Enums;

namespace ConsoleApp1.Models;
[Auditable]
public  class Comment
{
    public int Id { get; set; }

    public string? Title { get; set; }
    public bool IsConfirm { get; set; }  //تایید تویط ادمین

    public string? Description { get; set; }
    public DateTime? RegisterDate { get; set; }=DateTime.Now;

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
    public int? CustomertId { get; set; }

    public virtual Customer? Customer { get; set; }
}