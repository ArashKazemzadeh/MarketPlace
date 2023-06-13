using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.Optionals
{
   

    public class ImageForProductRepository : IImageForProductRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<ImageForProduct> _imageSet;

        public ImageForProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _imageSet = _dbContext.Set<ImageForProduct>();
        }

        public async Task<ImageForProduct> GetByIdAsync(int imageId)
        {
            return await _imageSet.FindAsync(imageId);
        }

        public async Task<IEnumerable<ImageForProduct>> GetImagesForProductAsync(int productId)
        {
            return await _imageSet.Where(i => i.ProductId == productId).ToListAsync();
        }
        public async Task<ImageForProduct> GetByUrlAsync(string url)
        {
            return await _imageSet.FirstOrDefaultAsync(image => image.Url == url);
        }

        public async Task AddAsync(ImageForProductRepDto imageDto)
        {
            var image = new ImageForProduct
            {
                Url = imageDto.Url,
                ProductId = imageDto.ProductId,
                Product = imageDto.Product
            };
            
            await _imageSet.AddAsync(image);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var image = await _imageSet.FindAsync(id);
            if (image!=null)
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

    }

}
