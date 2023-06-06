using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Areas.Admin.Models
{
    public class ProductForConfirmVM
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string? Name { get; set; }
        [Display(Name = "قیمت پایه")]
        public int? BasePrice { get; set; }
        [Display(Name = "مجاز جهت نمایش")]
        public bool? IsConfirm { get; set; }
        [Display(Name = "تعداد در انبار")]
        public int? Availability { get; set; }
        [Display(Name = "جزییات کالا")]
        public string? Description { get; set; }
        [Display(Name = "نام فروشنده")]
        public string? SellerName { get; set; }
    }
}
