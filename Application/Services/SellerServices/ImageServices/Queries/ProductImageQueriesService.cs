
using Application.IServices.SellerServices.ImageServices.Commands;
using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;

namespace Application.Services.SellerServices.ImageServices.Queries
{
    public class ProductImageQueriesService: IProductImageQueriesService
    {
        private readonly IImageRepository _imageRepository;
     

        public ProductImageQueriesService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
           
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
          var urls=  images.Select(i => i.Url).ToList();

            if (images != null)
            {
                return urls;
            }

            return new List<string>();
        }

    }
}
