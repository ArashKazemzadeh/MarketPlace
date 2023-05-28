using ConsoleApp1.Models;
using Domin.Enums;
using Domin.IRepositories.IseparationRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Optionals
{
    public class MedalRepository : IMedalRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Medal> _dbSet;

        public MedalRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Medal>();
        }

        public async Task<Medal> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Medal> GetMedalByTypeAsync(MedalEnum medalType)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Type == medalType);
        }


        public async Task<List<Medal>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Medal medal)
        {
            await _dbSet.AddAsync(medal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medal medal)
        {
            _context.Entry(medal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Medal medal)
        {
            _dbSet.Remove(medal);
            await _context.SaveChangesAsync();
        }
    }
}
