using Application.IServices.CustomerServices.ProductServices.Queries;
using Domin.IRepositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.CustomerServices.ProductServices.Queries
{
    public class GetAllProductsByBoothIdService : IGetAllProductsByBoothIdService
    {
        private readonly IBoothRepository _boothRepository;
        private readonly IProductRepository _productRepository;

        public GetAllProductsByBoothIdService(IBoothRepository boothRepository, IProductRepository productRepository)
        {
            _boothRepository = boothRepository;
            _productRepository = productRepository;
        }
        public async Task<List<ProductCustomerDto>> Execute(int boothId)
        {
            var booth = await _boothRepository.GetByIdAsync(boothId);
            if (booth == null)
            {
                return new List<ProductCustomerDto>();
            }

            var result = await _productRepository.GetProductByBoothIdAsync(boothId);
            if (result == null || result.Count() == 0)
            {
                return new List<ProductCustomerDto>();
            }

            return result;
        }
    }
}
