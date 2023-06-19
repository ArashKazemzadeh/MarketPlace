using Application.IServices.CustomerServices.CartService.Commands;
using Domin.IRepositories.IseparationRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerServices.CartService.Commands
{
    public class CartCommandService: ICartCommandService
    {
        private readonly ICartRepository _cartRepository;

        public CartCommandService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> FinalizeCartAsync(int cartId)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            if (cart == null)
            {
                return false;
            }

            cart.IsRegistrationFinalized = true;
            await _cartRepository.UpdateAsync(cart);
            return true; 
        }
    }
}
