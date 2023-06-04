using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.SqlServer;
using System;
using System.Collections.Generic;
using Domin.Entities.Users;

namespace Persistence.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }
        public async Task<User> GetUserByCustomerIdAsync(int customerId)
        {
            var user = await _dbSet.FindAsync(customerId);
            return user;
        }

        public async Task<List<User>> GetUsersByCustomerIdsAsync(List<int> customerIds)
        {
            var users = await _dbSet.Where(u => customerIds.Contains(u.Id)).ToListAsync();
            return users;
        }
    }
}
