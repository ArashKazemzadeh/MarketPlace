using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Areas.Seller.Models
{
    public class BoothSellerVM
    {   
        public int SellerId { get; set; } //+
        public int? BoothId { get; set; }
        public int? AddressId { get; set; }
        [Required(ErrorMessage = "این فیلد حتما باید پر شود")]
        [Display(Name = "نام حقیقی/حقوقی")]
        public string? CompanyName { get; set; }//+
        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "این فیلد حتما باید پر شود")]
        public string? City { get; set; }//+
        [Display(Name = "خیابان")]
        public string? Street { get; set; }//+
        [Display(Name = "توضیحات آدرس")]
        public string? AddressDescription { get; set; }//+
        [Required(ErrorMessage = "این فیلد حتما باید پر شود")]
        [Display(Name = "نام غرفه جهت نمایش")]
        public string? BoothName { get; set; }//+
        [Required(ErrorMessage = "این فیلد حتما باید پر شود")]
        [Display(Name = "توضیحات غرفه")]
        public string? BoothDescription { get; set; }//+

    }
}
