
using Application.IServices.SellerServices.ImageServices.Commands;
using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.ImageServices.Queries
{
    public class ProductImageQueriesService : IProductImageQueriesService
    {
        private readonly IImageRepository _imageRepository;
        private readonly ISellerRepository _sellerRepository;


        public ProductImageQueriesService(IImageRepository imageRepository, ISellerRepository sellerRepository)
        {
            _imageRepository = imageRepository;
            _sellerRepository = sellerRepository;
        }

        public async Task<List<ImageForProductRepDto>> GetAllImageProductBySellerId(int sellerId)
        {
            var seller = await _sellerRepository.GetByIdAsync(sellerId);
            if (seller == null)
            {
                return new List<ImageForProductRepDto>();
            }

            var result = await _imageRepository.GetAllImageProductBySellerId(sellerId);
            return result;
        }

        public async Task<Image> GetImageByIdAsync(int imageId)
        {
            return await _imageRepository.GetByIdAsync(imageId);
        }

        public async Task<IEnumerable<Image>> GetImagesForProductAsync(int productId)
        {
            return await _imageRepository.GetImagesForProductAsync(productId);
        }
        public async Task<List<string>> GetImageUrlForProduct(int productId)
        {
            var images = await _imageRepository.GetImagesForProductAsync(productId);
            var urls = images.Select(i => i.Url).ToList();

            if (images != null)
            {
                return urls;
            }

            return new List<string>();
        }

    }
}
