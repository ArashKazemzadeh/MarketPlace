using Application.IServices.CustomerServices.CartService.Commands;
using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Cart;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services.CustomerServices.CartService.Commands
{
    public class CartCommandService : ICartCommandService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductsCartRepository _productsCartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBoothRepository _boothRepository;
        public CartCommandService(
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IProductsCartRepository productsCartRepository,
            ICustomerRepository customerRepository,
            IBoothRepository boothRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _boothRepository = boothRepository;
            _productsCartRepository = productsCartRepository;
        }
        public async Task<bool> FinalizeCartAsync(int cartId)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            if (cart == null)
                return false;
            
            var result = await _cartRepository.FinalizeCartAsync(cartId);
            if (result)
                return true;
            return false;
        }
       
        public async Task<string> AddProductToCart(int customerId, int productId, int boothId)
        {
            #region Checking the nullity of the data

            var product = await _productRepository.GetByIdAsync(productId);
            var customer = await _customerRepository.GetByIdAsync(customerId);
            var booth = await _boothRepository.GetByIdAsync(boothId);
            if (product == null)
                return "کالا موجود نیست!";
            if (product.Availability < 1)
                return "موجودی کالا به اتمام رسیده است!";
            if (booth == null)
                return "غرفه موجود نیست!";
            if (customer == null)
                return "کاربری شما موجود نیست . ابتدا خارج و دوباره وارد شوید.";

            #endregion

            var openCartsOneCustomerInOneBooth = await _cartRepository.GetOpenCartsForCustomerIdByBoothIdAsync(boothId, customerId);
            if (openCartsOneCustomerInOneBooth.Count == 0)
            {
                #region Add to New Cart

                var newCart = new CartAddDto
                {
                    CustomerId = customerId,
                    SellerId = booth.SellerId,
                    TotalPrices = product.BasePrice,
                };
                var result = await _cartRepository.AddAsync(newCart);
                if (result == null)
                    throw new InvalidOperationException("SAVECHANGEASYNC() has encountered a problem and the card could not be registered in the database");

                var productsCart = new ProductsCartDto
                {
                    CartId = result.Id,
                    ProductId = productId,
                    Quantity = 1
                };
                await _productsCartRepository.AddAsync(productsCart);

                #endregion
            }
            else
            {
                #region Add To Exist Cart 

                var cart = openCartsOneCustomerInOneBooth.First();
                await _productsCartRepository.AddProductToOldCartAsync(cart.Id, productId);

                #endregion

            }
            product.Availability--;
            await _productRepository.UpdateAsync(product);
            return "کالا با موفقیت افزوده شد.";
        }

        public async Task<string> DeleteProductFromCart(string userId, int productId)
        {
            var customerId = Convert.ToInt32(userId);
            var result = await _productRepository.RemoveFromCartByProductId(productId, customerId);
            return result;
        }

        public async Task<string> DeleteOpenCart(string userId, int cartId)
        {
            var customerId = Convert.ToInt32(userId);
            var result = await _cartRepository.DeleteOpenCartAsync(customerId, cartId);
            return result;
        }
    }
}
