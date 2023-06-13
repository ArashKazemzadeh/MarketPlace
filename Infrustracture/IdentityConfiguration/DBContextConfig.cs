using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3.Configs;
using Microsoft.Extensions.Options;

namespace Infrustracture.IdentityConfiguration
{
    public static class DBContextConfig
    {
        public static IServiceCollection Add_AppConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Configs>(configuration.GetSection(nameof(Configs)));
            var serviceProvider = services.BuildServiceProvider();
            var config = serviceProvider.GetService<IOptions<Configs>>().Value;
            return services;
        }
        public static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configs = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.Development.json")
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .Build();
            configs.GetSection("ConnectionString");
            configs.GetSection("SqlPass");
            services.Configure<Configs>(configs.GetSection("Configs"));
            var configs2 = configs.GetSection("Configs");
            services.AddSingleton(configs2);
            services.Add_AppConfigs(configs);
            return services;
        }
    }
}
