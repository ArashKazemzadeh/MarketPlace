using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Orders
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Invoice> _dbSet;

        public InvoiceRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Invoice>();
        }

        public async Task<Invoice> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Invoice>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Invoice invoice)
        {
            await _dbSet.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Invoice invoice)
        {
            _dbSet.Remove(invoice);
            await _context.SaveChangesAsync();
        }
    }
}
