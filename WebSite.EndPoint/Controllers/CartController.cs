using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.CustomerServices.CartService.Commands;
using Application.IServices.CustomerServices.CartService.Queries;
using Application.IServices.CustomerServices.CommentServices.Commands;
using Domin.IRepositories.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Seller.Models;
using WebSite.EndPoint.Models.ViewModels;

namespace WebSite.EndPoint.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartQueryService _cartQueryService;
        private readonly ICartCommandService _cartCommandService;
        private readonly IAccountService _accountService;
        private readonly IAddCommentForProductService _addCommentForProductService;
        public CartController(ICartQueryService cartQueryService,
            IAccountService accountService,
            ICartCommandService cartCommandService, IAddCommentForProductService addCommentForProductService)
        {
            _cartQueryService = cartQueryService;
            _accountService = accountService;
            _cartCommandService = cartCommandService;
            _addCommentForProductService = addCommentForProductService;
        }
        public async Task<IActionResult> AddCommentForCart()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCommentForCart(CommentAddVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId =await _accountService.GetLoggedInUserId();
            var dto = new CommentAddDto
            {
                userId =userId,
                productId = model.productId,
                title = model.title,
                describtion = model.describtion
            };
            var result = await _addCommentForProductService.Execute(dto);
            if (result== "دیدگاه با موفقیت ثبت شد")
            {
                return RedirectToAction("MyCartsUnRegistered");
            }

            ViewBag.Message = result;
            return View(model);
        }

        public async Task<IActionResult> MyCartsUnRegistered()
        {
            var errorMessage = TempData["errorDoRegisteringCart"] as string;
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewBag.ErrorMessage = errorMessage;
            }

            var userId = await _accountService.GetLoggedInUserId();
            var dto = await _cartQueryService.GetUnfinalizedCartsByCustomerId(Convert.ToInt32(userId));
            var model = dto.Select(c => new CartGetVM
            {
                Id = c.Id,
                TotalPrices = c.TotalPrices,
                CustomerId = c.CustomerId,
                IsRegistrationFinalized = c.IsRegistrationFinalized,
                BoothName = c.BoothName,
                boothId = c.boothId,
                ProductsNames = c.ProductsNames
            }).ToList();
            return View(model);
        }

        public async Task<IActionResult> MyCartsRegistered()
        {
            var userId = await _accountService.GetLoggedInUserId();
            var dto = await _cartQueryService.GetfinalizedCartsByCustomerId(Convert.ToInt32(userId));
            var model = dto.Select(c => new CartGetVM
            {
                Id = c.Id,
                TotalPrices = c.TotalPrices,
                CustomerId = c.CustomerId,
                IsRegistrationFinalized = c.IsRegistrationFinalized,
                BoothName = c.BoothName,
                boothId = c.boothId,
                ProductsNames = c.ProductsNames
            }).ToList();
            return View(model);
        }

        public async Task<IActionResult> DoRegisteringCart(int cartId)
        {
            var dto = await _cartCommandService.FinalizeCartAsync(cartId);
            if (dto)
            {
                return RedirectToAction("MyCartsRegistered");
            }

            TempData["errorDoRegisteringCart"] = "سبد خرید یافت نشد";
            return RedirectToAction("MyCartsUnRegistered");
        }

        public async Task AddToCartBasePrice(int customerId,int productId,int boothId)
        {
         var result=   await _cartCommandService.AddProductToCart(customerId, productId, boothId);
         if (true)
             ViewBag.response = "کالا با موفقیت به سبد افزوده شد";
             ViewBag.response = "افزودن کالا به سبد خرید با مشکل مواجه شد";
        }
    }
}
