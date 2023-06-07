using Application.IServices.AdminServices.UserService.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.EndPoint.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private readonly IIdentityRoleService _roleService;

        public RolesController(IIdentityRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IActionResult> AddUserToRole(string userId, string role)
        {
            var result = await _roleService.AddUserToRoleAsync(userId, role);
            if (result)
            {
                // عملیات اضافه کردن به نقش موفقیت آمیز بود
                return RedirectToAction("Index");
            }
            else
            {
                // عملیات اضافه کردن به نقش ناموفق بود
                // می‌توانید مناسب به آن رفتار کنید (مثلاً نمایش خطا یا ریدایرکت به صفحه دیگر)
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> RemoveUserFromRole(string userId, string role)
        {
            var result = await _roleService.RemoveUserFromRoleAsync(userId, role);
            if (result)
            {
                // عملیات حذف از نقش موفقیت آمیز بود
                return RedirectToAction("Index");
            }
            else
            {
                // عملیات حذف از نقش ناموفق بود
                // می‌توانید مناسب به آن رفتار کنید (مثلاً نمایش خطا یا ریدایرکت به صفحه دیگر)
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> GetUserRoles(string userId)
        {
            var roles = await _roleService.GetUserRolesAsync(userId);
            if (roles == null)
            {
                // کاربر یافت نشد
                // می‌توانید مناسب به آن رفتار کنید (مثلاً نمایش خطا یا ریدایرکت به صفحه دیگر)
                return RedirectToAction("Error");
            }

            // نمایش نقش‌های کاربر
            return View(roles);
        }

        public async Task<IActionResult> CreateRole(string roleName)
        {
            var result = await _roleService.CreateRoleAsync(roleName);
            if (result)
            {
                // عملیات ایجاد نقش موفقیت آمیز بود
                return RedirectToAction("Index");
            }
            else
            {
                // عملیات ایجاد نقش ناموفق بود
                // می‌توانید مناسب به آن رفتار کنید (مثلاً نمایش خطا یا ریدایرکت به صفحه دیگر)
                return RedirectToAction("Error");
            }
        }

        // سایر اکشن‌ها و روش‌های کنترلر
    }

}
