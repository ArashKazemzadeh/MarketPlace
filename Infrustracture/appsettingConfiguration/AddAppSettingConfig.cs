
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebSite.EndPoint.Utilities.AppSettings.Models;
using WebSite.EndPoint.Utilities.AppSettings.Services;

namespace Infrustracture.appsettingConfiguration
{
    public static class AddAppSettingConfig
    {
        public static IServiceCollection AddAppSettingService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<WelcomeMessageSettings>(configuration.GetSection("WelcomeMessageSettings"));
            services.AddSingleton<IWelcomeMessageService, WelcomeMessageService>();
            return services;
        }
    }
}
