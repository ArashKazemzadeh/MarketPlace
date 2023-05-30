using Application.Dtos;
using Application.IServices.AdminServices.ProoductServices.Commands;
using AutoMapper;
using ConsoleApp.Models;
using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.AdminServices.ProoductServices.Commands
{
    public class UpdateProductAdminService : IUpdateProductAdminService
    {
        private readonly IProductRepository _productRepository;
        //private readonly IMapper _mapper;

        public UpdateProductAdminService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            //_mapper = mapper;
            //_mapper.ConfigurationProvider.CreateMapper();
        }

        public async Task<GeneralDto> Execute(ProductDto product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.Id);
            if (existingProduct == null)
                return new GeneralDto
                {
                    message = "کالا موجود نیست"
                };
            existingProduct.Name = product.Name;
            existingProduct.BasePrice = product.BasePrice;
            existingProduct.IsAuction = product.IsAuction;
            existingProduct.IsConfirm = product.IsConfirm;
            existingProduct.Availability = product.Availability;
            existingProduct.Description = product.Description;
            existingProduct.IsActive = product.IsActive;
            existingProduct.BidId = product.BidId;
            await _productRepository.UpdateAsync(existingProduct);
            //var updatedProductDto = _mapper.Map<ProductDto>(existingProduct);
            return new GeneralDto
            {
                message = "به روز رسانی انجام شد."
            };
        }
    }


}
