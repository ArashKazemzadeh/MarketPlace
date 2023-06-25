using System.ComponentModel.DataAnnotations;

namespace WebSite.EndPoint.Areas.Customer.Models;

public class PasswordUpdateVM
{
    [Display(Name = "گذرواژه فعلی")]
    [Required(ErrorMessage = "این فیلد باید حتما پر شود")]
    [DataType(DataType.Password)]
    public string currentPassword { get; set; }

    [Required(ErrorMessage = "گذرواژه را وارد نمایید")]
    [DataType(DataType.Password)]
    [Display(Name = "گذرواژه جدید")]
    public string newPassword { get; set; }
    [Display(Name = " باز نویس گذرواژه جدید")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "بازنویس گذرواژه را وارد نمایید")]
    [Compare(nameof(newPassword), ErrorMessage = "گذرواژه و بازنویس آن باید برابر باشد")]
    public string RenewPassword { get; set; }

}