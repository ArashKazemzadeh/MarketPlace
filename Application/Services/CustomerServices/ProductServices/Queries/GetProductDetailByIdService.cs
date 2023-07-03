using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos;
using Application.IServices.CustomerServices.ProductServices.Queries;
using Domin.IRepositories.Dtos.Product;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.CustomerServices.ProductServices.Queries
{
    public class GetProductDetailByIdService: IGetProductDetailByIdService
    {
        private readonly IProductRepository _productRepository;

        public GetProductDetailByIdService(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
        }

        public async Task<GeneralDto<ProductDto> >Execute(int productId)
        {
            var product = await _productRepository.GetWithAllNavigationsByIdSellerAsync(productId);
            if (product==null)
            {
                return new GeneralDto<ProductDto> { message = "Null"};
            }

            return new GeneralDto<ProductDto>
            {
                message = "200",
                Data = product
            };
        }
    }
}
