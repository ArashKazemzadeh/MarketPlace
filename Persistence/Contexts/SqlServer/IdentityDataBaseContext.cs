using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domin.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts.SqlServer
{
    public class IdentityDataBaseContext:IdentityDbContext<User>
    {
        public IdentityDataBaseContext(DbContextOptions<IdentityDataBaseContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
