using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrustracture.appsettingConfiguration
{
    public static class AddAppSettingConfig
    {

        public static IServiceCollection AddConfigService(this IServiceCollection services,
            IConfiguration configuration)
        {

            var configs = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.Development.json");
            return services;
        }
    }
}
