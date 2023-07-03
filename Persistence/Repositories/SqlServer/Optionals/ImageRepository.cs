using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Image;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.SqlServer.Optionals
{


    public class ImageRepository : IImageRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<Image> _imageSet;

        public ImageRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _imageSet = _dbContext.Set<Image>();
        }

        public async Task<Image> GetByIdAsync(int imageId)
        {
            return await _imageSet.FindAsync(imageId);
        }
        public async Task<List<ImageForProductRepDto>> GetAllImageProductBySellerId(int sellerId)
        {

            var images = await _imageSet
                .Where(i => i.Product.Booth.Seller.Id == sellerId)
                .Select(i => new ImageForProductRepDto
                {
                    Id = i.Id,
                    Url = i.Url,
                    ProductId = i.ProductId,
                    Product = i.Product
                })
                .Take(1)
                .ToListAsync();

            return images;
        }
        public async Task<Image> GetBySellerIdAsync(int sellerId)
        {
            var result = await _imageSet.SingleOrDefaultAsync(i => i.SellerId == sellerId);
            return result;
        }
        public async Task<IEnumerable<Image>> GetImagesForProductAsync(int productId)
        {
            return await _imageSet.Where(i => i.ProductId == productId).ToListAsync();
        }
        public async Task<Image> GetByUrlAsync(string url)
        {
            return await _imageSet.FirstOrDefaultAsync(image => image.Url == url);
        }

        public async Task<int> AddAsync(ImageForProductRepDto imageDto)
        {
            var image = new Image
            {
                Url = imageDto.Url,
                ProductId = imageDto.ProductId,
                //Product = imageDto.Product
            };

            await _imageSet.AddAsync(image);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }



        public async Task<bool> RemoveAsync(int id)
        {
            var image = await _imageSet.FindAsync(id);
            if (image != null)
            {
                _imageSet.Remove(image);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveAsync(string url)
        {
            var image = await _imageSet.FirstOrDefaultAsync(image => image.Url == url);
            if (image != null)
            {
                _imageSet.Remove(image);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public async Task<Image> GetProfileImageBySellerId(int sellerId)
        {
            var Result = await _imageSet.FirstOrDefaultAsync(i => i.SellerId == sellerId);
            if (Result == null)
            {
                return null;
            }

            return Result;
        }
        public async Task<int> AddAsync(ImageUserAddDto imageDto)
        {
            var image = new Image
            {
                Url = imageDto.Url,
                SellerId = imageDto.SellerId,

            };

            await _imageSet.AddAsync(image);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }

}
