using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IServices.CustomerServices.CartService.Queries;
using Domin.IRepositories.Dtos.Cart;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.CustomerServices.CartService.Queries
{
    public class CartQueryService: ICartQueryService
    {
        private readonly ICartRepository _cartRepository;

        public CartQueryService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<List<CartGetDto>> GetUnfinalizedCartsByCustomerId(int customerId)
        {
            var result = await _cartRepository.GetUnfinalizedCartsByCustomerId(customerId);
            if (result==null ||result.Count==0)
            {
                return new List<CartGetDto>();
            }

            return result;
        }
        public async Task<List<CartGetDto>> GetfinalizedCartsByCustomerId(int customerId)
        {
            var result = await _cartRepository.GetfinalizedCartsByCustomerId(customerId);
            if (result == null || result.Count == 0)
            {
                return new List<CartGetDto>();
            }

            return result;
        }

        public async Task<List<ProductDto>> GetProductByCartId(int cartId)
        {
            var result = await _cartRepository.GetProductByCartId(cartId);
            return result;
        }
    }
}
