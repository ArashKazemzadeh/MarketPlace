using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Optionals
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Comment> _dbSet;

        public CommentRepository(DbContext context)
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

        public async Task AddAsync(Comment comment)
        {
            await _dbSet.AddAsync(comment);
            await _context.SaveChangesAsync();
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
