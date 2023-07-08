using ConsoleApp1.Models;
using Domin.IRepositories.Dtos.Comment;
using Domin.IRepositories.IseparationRepository.SqlServer;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.SqlServer.Optionals
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Comment> _dbSet;

        public CommentRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<Comment>();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<CommentGetDto>> GetByProductIdAsync(int productId)
        {
            var comments = await _dbSet.AsNoTracking()
                .Where(c => c.ProductId == productId /*&& c.IsConfirm==true*/)
                .Include(p => p.Product)
                .Include(c => c.Customer)
                .ToListAsync();
            var result = comments.Select(c => new CommentGetDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                RegisterDate = c.RegisterDate,
                Product = c.Product,
                CustomerId = c.CustomertId
            }).ToList();
            return result;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<List<Comment>> GetAllCommentsWithSellerNameConfirmAsync()
        {
            var comments = await _dbSet.Where(x => x.IsConfirm == null )
                .Include(c => c.Product)
                .ThenInclude(p => p.Booth)
                .ThenInclude(b => b.Seller)
                .ToListAsync();

            return comments;
        }
        public async Task<int> AddAsync(CommentAddDto dto)
        {
            var comment = new Comment
            {
                Title = dto.title,
                Description = dto.describtion,
                CustomertId = Convert.ToInt32(dto.userId),
                ProductId = dto.productId,
                RegisterDate = DateTime.Now,
            };
            await _dbSet.AddAsync(comment);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task UpdateAsync(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Comment comment)
        {
            _dbSet.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }

}
