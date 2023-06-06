using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Areas.Admin.Models
{
    public class ProductVm
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string? Name { get; set; }
        [Display(Name = "قیمت پایه")]
        public int? BasePrice { get; set; }
        [Display(Name = "وضعیت مزایده")]
        public bool IsAuction { get; set; }
        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }
        [Display(Name = " تایید/عدم تایید")]
        public bool? IsConfirm { get; set; }
        [Display(Name = "تعداد در انبار")]
        public int? Availability { get; set; }
        [Display(Name = "جزییات کالا")]
        public string? Description { get; set; }
        [Display(Name = "نام شرکت/برند/فروشنده")]
        public string? SellerName { get; set; }
    }
}







