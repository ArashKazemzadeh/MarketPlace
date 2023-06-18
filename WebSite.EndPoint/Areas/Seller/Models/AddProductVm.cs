using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Areas.Seller.Models
{
    public class AddProductVm
    {
        [Required(ErrorMessage = "این فیلد حتما باید پر شود")]
        [Display(Name = "نام کالا")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "این فیلد حتما باید پر شود")]
        [Display(Name = "قیمت پایه")]
        public int? BasePrice { get; set; }
        [Required(ErrorMessage = "این فیلد حتما باید پر شود")]
        [Display(Name = "موجودی")]
        public int? Availability { get; set; }
        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; } 

        public SelectList CategoryList { get; set; } 
    }
}
