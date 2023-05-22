using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrustracture.IdentityConfiguration
{
    public static class DBContextConfig
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlserver") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString));
            return null;
        }
    }
}
