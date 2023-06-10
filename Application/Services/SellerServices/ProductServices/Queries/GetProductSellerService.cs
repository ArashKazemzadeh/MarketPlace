using Application.Dtos;
using Application.Dtos.ProductDto;
using Application.IServices.SellerServices.ProductServices.Queries;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.ProductServices.Queries
{
    public class GetProductSellerService : IGetProductSellerService
    {
        private readonly IProductRepository _productRepository;

        public GetProductSellerService(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
        }

        public async Task<GeneralDto<ProductGeneralDto>> FindByIdAsync(int id)
        {
            var productDto = await _productRepository.GetByIdAsync(id);
            if (productDto == null)
            {
                return new GeneralDto<ProductGeneralDto>
                {
                    message = "کاربر یافت نشد."
                };
            }
            return new GeneralDto<ProductGeneralDto>
            {
                message = "با موفقیت یافت شد.",
                Data = new ProductGeneralDto
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    BasePrice = productDto.BasePrice,
                    IsAuction = productDto.IsAuction,
                    IsConfirm = productDto.IsConfirm,
                    Availability = productDto.Availability,
                    Description = productDto.Description,
                    IsActive = productDto.IsActive,
                    Auction = productDto.Auction,
                    Categories = productDto.Categories
                }
            };
        }

        public async Task<GeneralDto<List<ProductGeneralDto>>> GetAllProductBySellerIdAsync(int sellerId)
        {
            var products = await _productRepository.GetAllWithNavigationsAsync(sellerId);
            if (products==null)
            {
                return new GeneralDto<List<ProductGeneralDto>>
                {
                    message = "لیست کالاموجود نیست."
                };
            }

            var result = products.Select(p => 
            
                new ProductGeneralDto
                {
                    Name = p.Name,
                    BasePrice = p.BasePrice,
                    IsAuction = p.IsAuction,
                    IsConfirm = p.IsConfirm,
                    Availability = p.Availability,
                    Description = p.Description,
                    IsActive = p.IsActive,
                    Auction = p.Auction,
                    Image = p.Image,
                    Categories = p.Categories
                }).ToList();
            return new GeneralDto<List<ProductGeneralDto>>
            {
                message = "لیست کالا یافت شد",
                Data = result
            };
        }
    }
}
