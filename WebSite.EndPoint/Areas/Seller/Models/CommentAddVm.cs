using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Areas.Seller.Models;

public class CommentAddVm
{
    public int productId { get; set; }
    [Required(ErrorMessage = "این فیلد حتما باید پر شود")]
    [Display(Name = "عنوان")]
    public string title { get; set; }
    [Required(ErrorMessage = "این فیلد حتما باید پر شود")]
    [Display(Name = "شرح دیدگاه")]
    public string describtion { get; set; }
}