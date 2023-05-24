using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Models.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد نمایید")]
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا پسورد خود را وارد نمایید")]
        [Display(Name = "پسورد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا به یاد بیاور")]
        public bool IsPersistent { get; set; } = false; 

        public string ReturnUrl { get; set; } //باز گرداندن کاربر به صفحه ی قبل از احراز هویت
    }
}
