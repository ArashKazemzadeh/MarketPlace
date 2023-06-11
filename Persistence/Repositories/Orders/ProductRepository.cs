using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;


namespace Persistence.Repositories.Orders
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        public async Task<List<AuctionProductDto>> GetProductsWithTrueAuctions(int sellerId)
        {
            var result = _dbSet.AsNoTracking().Where(a => a.IsActive && a.Booth.Seller.Id == sellerId)
                .Include(a => a.Auction)
                .Select(p => new AuctionProductDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    BasePrice = p.BasePrice ?? 0,
                    AuctionId = p.Auction.Id,
                    StartDeadTime = p.Auction.StartDeadTime,
                    EndDeadTime = p.Auction.EndDeadTime,
                    HighestPrice = p.Auction.HighestPrice
                }).ToList();

            return result;
        }


        public async Task<ProductDto> GetWithAllNavigationsByIdSellerAsync(int id)
        {
            var product = await _dbSet.AsNoTracking().Where(x => x.Id == id)
                    .Include(b => b.Auction)

                    .Include(c => c.Categories)
                    .FirstOrDefaultAsync();
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                BasePrice = product.BasePrice,
                IsAuction = product.IsAuction,
                IsConfirm = product.IsConfirm,
                Availability = product.Availability,
                Description = product.Description,
                IsActive = product.IsActive,
                Auction = product.Auction,
                Categories = product.Categories
            };
        }
        public async Task<List<Product>> GetProductsWithSellerNameConfirmAsync()
        {
            var products = await _dbSet.AsNoTracking().Where(x => x.IsConfirm == null)
                .Include(p => p.Booth)
                .ThenInclude(b => b.Seller).ToListAsync();
            return products;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<List<ProductDto>> GetAllWithNavigationsAsync(int sellerId)
        {
            var products = await _dbSet.AsNoTracking().Where(x => x.Id == sellerId)
                .Include(b => b.Auction)
                .Include(i => i.Images)
                .Include(c => c.Categories).ToListAsync();

            var result = products.Select(p => new ProductDto
            {

                Id = p.Id,
                Name = p.Name,
                BasePrice = p.BasePrice,
                IsAuction = p.IsAuction,
                IsConfirm = p.IsConfirm,
                Availability = p.Availability,
                Description = p.Description,
                IsActive = p.IsActive,
                Auction = p.Auction,
                Image = p.Images,
                Categories = p.Categories

            }).ToList();
            return result;
        }

        public async Task AddAsync(ProductAddDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                BasePrice = productDto.BasePrice,
                Description = productDto.Description,
                Availability = productDto.Availability,
                BoothId = productDto.BoothId,
                Booth = productDto.Booth
            };
            await _dbSet.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var result = await _dbSet.FindAsync(productDto.Id);
            result.Id = productDto.Id;
            result.Name = productDto.Name;
            result.BasePrice = productDto.BasePrice;
            result.IsAuction = productDto.IsActive;
            result.Availability = productDto.Availability;
            result.Description = productDto.Description;
            result.IsActive = productDto.IsActive;

            if (result != null)
            {
                _context.Entry(result).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteAsync(int id)
        {
            var product = await _dbSet.FindAsync(id);
            if (product != null)
            {
                product.IsRemove = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
