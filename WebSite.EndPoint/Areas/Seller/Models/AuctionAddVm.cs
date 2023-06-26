using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Areas.Seller.Models
{
    public class AuctionAddVm
    {
        [Display(Name = "زمان آغاز مزایده")]
        [Required(ErrorMessage = "فیلد را پر کنید")]
        public DateTime? StartDeadTime { get; set; }
        [Display(Name = "زمان پایان مزایده")]
        [Required(ErrorMessage = "فیلد را پر کنید")]
        public DateTime? EndDeadTime { get; set; }
        public int ProductId { get; set; }
    }
}
