using Application.IServices.CustomerServices.CartService.Commands;
using Domin.IRepositories.Dtos.Cart;
using Domin.IRepositories.IseparationRepository;

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
            {
                return false;
            }
            var result = await _cartRepository.FinalizeCartAsync(cartId);
            if (result)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> AddProductToCart(int customerId, int productId, int boothId)
        {
            // بررسی وجود کالا و موجودی آن
            var product = await _productRepository.GetByIdAsync(productId);
            var customer = await _customerRepository.GetByIdAsync(customerId);
            var booth = await _boothRepository.GetByIdAsync(boothId);
            if (product == null || product.Availability <= 0 || booth == null || customer == null)
                return false;
            // بررسی کارت های یک مشتری با IsRegistrationFinalized=false که دارای boothId مورد نظر هستند
            var openCartsOneCustomerInOneBooth = await _cartRepository.GetOpenCartsForCustomerIdByBoothIdAsync(boothId, customerId);
            if (openCartsOneCustomerInOneBooth.Count == 0)
            {
                // ایجاد کارت جدید
                var newCart = new CartAddDto
                {
                    CustomerId = customerId,
                    SellerId = product.Booth.SellerId,
                    TotalPrices = product.BasePrice,
                };
                var result = await _cartRepository.AddAsync(newCart);
                if (result==null)
                {
                    throw new InvalidOperationException("SAVECHANGEASYNC() has encountered a problem and the card could not be registered in the database");

                }
                // افزودن کالا به کارت
                var productsCart = new ProductsCartDto
                {
                    CartId = result.Id,
                    ProductId = productId,
                    Quantity = 1
                };
                _productsCartRepository.AddAsync(productsCart);
            }
            else
            {
                // افزودن کالا به کارتی که پیدا شده است
                var cart = openCartsOneCustomerInOneBooth.First();
                await _productsCartRepository.AddProductToCartAsync(cart.Id, productId);
            }
            // کم کردن تعداد کالا از دیتابیس
            product.Availability--;
            await _productRepository.UpdateAsync(product);
            return true;
        }
    }
}
