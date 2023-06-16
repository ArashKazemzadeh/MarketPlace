using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Infrustracture.CookiesConfiguration;




    public static class AddCookies
    {
        public static IServiceCollection AddCookiesService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureApplicationCookie(option =>
            {
                option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                option.LoginPath = "/account/login";
                option.AccessDeniedPath = "/Account/AccessDenied";
                option.SlidingExpiration = true;
            });
            return services;

        }
    }

