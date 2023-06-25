using ConsoleApp1.Models;
using Domin.IRepositories.Dtos;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;

namespace Persistence.Repositories.Optionals
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

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<List<Comment>> GetAllCommentsWithSellerNameConfirmAsync()
        {
            var comments = await _dbSet.Where(x => x.IsConfirm == null)
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
                CustomertId =Convert.ToInt32(dto.userId) ,
                ProductId = dto.productId,
                RegisterDate = DateTime.Now,
            };
            await _dbSet.AddAsync(comment);
       var result=     await _context.SaveChangesAsync();
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
