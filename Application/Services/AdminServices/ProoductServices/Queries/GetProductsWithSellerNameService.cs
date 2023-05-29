using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IServices.AdminServices.ProoductServices.Queries;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.ProoductServices.Queries
{


    public class GetProductsWithSellerNameAsyncService : IGetProductsWithSellerNameAsyncService

    {
        private readonly IProductRepository _productRepository;

        public GetProductsWithSellerNameAsyncService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Execute()
        {
            var products = await _productRepository.GetProductsWithSellerNameConfirmAsync();

            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                BasePrice = p.BasePrice,
                IsAuction = p.IsAuction,
                IsConfirm = p.IsConfirm ?? false,
                Availability = p.Availability,
                Description = p.Description,
                SellerName = p.Booth?.Seller?.CompanyName,
                IsActive = p.IsActive,
                BidId = p.BidId
            }).ToList();

            return productDtos;
        }
    }
}

