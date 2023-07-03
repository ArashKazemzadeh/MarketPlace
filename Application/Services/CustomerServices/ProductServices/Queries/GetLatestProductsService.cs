using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IServices.CustomerServices.ProductServices.Queries;
using Domin.IRepositories.Dtos.Product;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.CustomerServices.ProductServices.Queries
{
    public class GetLatestProductsService: IGetLatestProductsService
    {
        private readonly IProductRepository _productRepository;

        public GetLatestProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductGetDto>> Execute()
        {
            return  await _productRepository.GetAllProductsForView();
        }
    }
}
