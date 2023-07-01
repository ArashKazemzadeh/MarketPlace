﻿using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;


namespace Persistence.Repositories.SqlServer.Orders
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



        public async Task<List<ProductCustomerDto>> GetProductByBoothIdAsync(int boothId)
        {
            var dto = await _dbSet.Where(x => x.Booth.Id == boothId && x.IsAuction == false).Select(p => new ProductCustomerDto
            {
                BoothId = p.Booth.Id,
                Name = p.Name,
                Description = p.Description,
                BasePrice = p.BasePrice,
                Availability = p.Availability,
                Id = p.Id,
                ImagesUrls = p.Images.Select(u => u.Url).ToList(),
                Categories = p.Categories.Select(n => n.Name).ToList(),
                BoothName = p.Booth.Name,
                IsActive = p.IsActive
            }).ToListAsync();
            return dto;
        }

        public async Task<List<AuctionProductDto>> GetProductsWithTrueAuctions(int sellerId)
        {
            var result = await _dbSet.Where(a => a.IsAuction == true && a.IsActive == true && a.Booth.Seller.Id == sellerId)
                .Select(p => new AuctionProductDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    BasePrice = p.BasePrice ?? 0,
                    AuctionId = p.Auction.Id,
                    StartDeadTime = p.Auction.StartDeadTime,
                    EndDeadTime = p.Auction.EndDeadTime,
                    HighestPrice = p.Auction.HighestPrice
                }).ToListAsync();

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

        public async Task<List<ProductDto>> GetAllWithNavigationsAsync(int? boothId)
        {
            var products = await _dbSet.AsNoTracking().Where(x => x.BoothId == boothId)
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

        public async Task<int> AddAsync(ProductAddDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                BasePrice = productDto.BasePrice,
                Description = productDto.Description,
                Availability = productDto.Availability,
                BoothId = productDto.BoothId,
            };
            await _dbSet.AddAsync(product);
            await _context.SaveChangesAsync();
            var id = product.Id;
            return id;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var result = await _dbSet.FindAsync(productDto.Id);

            if (result != null)
            {
                result.Name = productDto.Name;
                result.BasePrice = productDto.BasePrice;
                result.Availability = productDto.Availability;
                result.Description = productDto.Description;

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
            var redult = await _dbSet.Where(p => p.Id == id).Include(c => c.Categories).FirstOrDefaultAsync();
            return redult;
        }

        public async Task UpdateAsync(ProductDto productDto, List<int> categoryIds)
        {
            var result = await _dbSet.FindAsync(productDto.Id);

            if (result != null)
            {
                result.Name = productDto.Name;
                result.BasePrice = productDto.BasePrice;
                result.Availability = productDto.Availability;
                result.Description = productDto.Description;

                // به روزرسانی دسته‌بندی‌ها
                result.Categories = await _context.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();

                _context.Entry(result).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

    }
}