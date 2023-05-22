using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.Optionals
{
    public class FileForUserRepository : IFileForUserRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<FileForUser> _dbSet;

        public FileForUserRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<FileForUser>();
        }

        public async Task<FileForUser> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<FileForUser>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(FileForUser fileForUser)
        {
            await _dbSet.AddAsync(fileForUser);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FileForUser fileForUser)
        {
            _context.Entry(fileForUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(FileForUser fileForUser)
        {
            _dbSet.Remove(fileForUser);
            await _context.SaveChangesAsync();
        }
    }
}
