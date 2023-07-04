using Application.Dtos.UserDto;
using Application.IServices.AdminServices.UserService.Commands;
using Application.IServices.CustomerServices.CartService.Commands;
using Application.IServices.CustomerServices.CartService.Queries;
using Application.IServices.CustomerServices.CommentServices.Commands;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.Dtos.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSite.EndPoint.Areas.Seller.Models;
using WebSite.EndPoint.Models.ViewModels;

namespace WebSite.EndPoint.Controllers
{
    [Authorize]
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

        public async Task<IActionResult> GetProductsInCloseCart(int cartId)
        {
            var products = await _cartQueryService.GetProductByCartId(cartId);
            var model = products
                .Select(p => new ProductInCartVM()
                {
                    ProductId = p.ProductId,
                    BasePrice = p.BasePrice,
                    Name = p.Name,
                    TotalPrice = p.TotalPrice,
                    Quantity = p.Quantity,
                }).ToList();

            return View(model);
        }
        public async Task<IActionResult> GetProductsInOpenCart(int cartId)
        {
            var products = await _cartQueryService.GetProductByCartId(cartId);
            var model = products
                .Select(p => new ProductInCartVM()
                {
                    ProductId = p.ProductId,
                    BasePrice = p.BasePrice,
                    Name = p.Name,
                    TotalPrice = p.TotalPrice,
                    Quantity = p.Quantity,
                  BoothId = p.BoothId,
                  CartId=cartId
                }).ToList();
            ViewBag.Message = TempData["DeleteProductFromCart"];
            return View(model);
        }
        public async Task<IActionResult> AddCommentForCart(int ProductId)
        {
            var model = new CommentAddVm
            {
                productId = ProductId
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentForCart(CommentAddVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = await _accountService.GetLoggedInUserId();
            var dto = new CommentAddDto
            {
                userId = userId,
                productId = model.productId,
                title = model.title,
                describtion = model.describtion
            };
            var result = await _addCommentForProductService.Execute(dto);
            if (result == "دیدگاه با موفقیت ثبت شد")
            {
                return RedirectToAction("MyCartsRegistered");
            }

            ViewBag.Message = result;
            return View(model);
        }
        public async Task<IActionResult> MyCartsUnRegistered()
        {
            var errorMessage = TempData["errorDoRegisteringCart"] as string;
          
                ViewBag.ErrorMessage = errorMessage;
            var deleteMessage = TempData["DeleteProductFromCart"] as string;
            
                ViewBag.deleteMessage = deleteMessage;

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
                ProductsNames = c.ProductsNames,
                QuantityFromOne = c.QuantityFromOne
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
                BoothName = c.BoothName,
                ProductsNames = c.ProductsNames,
                RegisterDate = c.RegisterDate,
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
        public async Task<IActionResult> AddToCartBasePrice(int productId, int boothId)
        {
            var userId = await _accountService.GetLoggedInUserId();
            var result = await _cartCommandService.AddProductToCart(Convert.ToInt32(userId), productId, boothId);

            TempData["AddToCartBasePrice"] = result;
            if (true)
            {
                return RedirectToAction("EnterToBooth", "Booth", new {boothId = boothId});
            }

        }
        public async Task<IActionResult> RemoveOneByOne(int productId,int cartId)
        {
            var UserId = await _accountService.GetLoggedInUserId();
            var result = await _cartCommandService.DeleteProductFromCart(UserId, productId);
            if (result == "عملیات با موفقیت انجام شد")
            {
                TempData["RemoveOneByOne"] = result;
                return RedirectToAction("GetProductsInOpenCart",new {cartId=cartId});
            }

            TempData["RemoveOneByOne"] = result;
            return RedirectToAction("GetProductsInOpenCart",new {cartId=cartId});
        }
        public async Task<IActionResult> AddOneByOne(int productId,int boothId ,int cartId)
        {
            var UserId = await _accountService.GetLoggedInUserId();
            var result = await _cartCommandService.AddProductToCart(Convert.ToInt32(UserId), productId, boothId);
            if (result == "عملیات با موفقیت انجام شد")
            {
                TempData["AddOneByOne"] = result;
                return RedirectToAction("GetProductsInOpenCart");
            }

            TempData["AddOneByOne"] = result;
            return RedirectToAction("GetProductsInOpenCart", new { cartId = cartId });
        }
        public async Task<IActionResult> DeleteOprnCart(int cartId)
        {
            var UserId = await _accountService.GetLoggedInUserId();
            var result = await _cartCommandService.DeleteOpenCart(UserId, cartId);
            if (result == "عملیات با موفقیت انجام شد")
            {
                TempData["DeleteProductFromCart"] = result;
                return RedirectToAction("MyCartsUnRegistered");
            }

            TempData["DeleteProductFromCart"] = result;
            return RedirectToAction("MyCartsUnRegistered");
        }
    }
}
