using Application.IServices.SellerServices.ImageServices.Queries;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;


namespace Application.Services.SellerServices.ImageServices.Commands
{
    public class ProductImageCommandsService : IProductImageCommandsService
    {
        private readonly IImageForProductRepository _imageForProductRepository;
        private readonly IProductRepository _productRepository;

        public ProductImageCommandsService(IImageForProductRepository imageForProductRepository,
            IProductRepository productRepository)
        {
            _imageForProductRepository = imageForProductRepository;
            _productRepository = productRepository;
        }

        public async Task<string> AddImageToProduct(int productId, string imageUrl)
        {

            var product = await _productRepository.GetByIdAsync(productId);

            if (product == null)
            {
                return " خطا ی عدم یافتن کالا";
            }

            var image = new ImageForProductRepDto()
            {
                Url = imageUrl,
                ProductId = productId,
                Product = product
            };

            _imageForProductRepository.AddAsync(image);
            return $" عکس به {image.Product.Name}افزوده شد.";
        }

        public async Task<string> DeleteImageFromProduct(int id)
        {
            if (id != 0)
            {
                await _imageForProductRepository.RemoveAsync(id);
                return "عکس حذف شد";
            }

            return "عکس پیدا نشد.";
        }

    }

}
