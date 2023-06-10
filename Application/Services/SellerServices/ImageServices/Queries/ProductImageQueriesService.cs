
using Application.IServices.SellerServices.ImageServices.Commands;
using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.ImageServices.Queries
{
    public class ProductImageQueriesService: IProductImageQueriesService
    {
        private readonly IImageForProductRepository _imageRepository;
     

        public ProductImageQueriesService(IImageForProductRepository imageRepository)
        {
            _imageRepository = imageRepository;
           
        }

        public async Task<ImageForProduct> GetImageByIdAsync(int imageId)
        {
            return await _imageRepository.GetByIdAsync(imageId);
        }

        public async Task<IEnumerable<ImageForProduct>> GetImagesForProductAsync(int productId)
        {
            return await _imageRepository.GetImagesForProductAsync(productId);
        }
    }
}
