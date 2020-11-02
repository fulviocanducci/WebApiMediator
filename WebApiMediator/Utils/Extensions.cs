using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiMediator.Models;

namespace WebApiMediator.Utils
{
    public static class Extensions
    {
        public static IServiceCollection AddDbContextBaseMediator(
            this IServiceCollection services, IConfiguration configuration
        )
        {
            services.AddDbContext<BasemediatorContext>(config =>
            {
                config.UseSqlServer(configuration.GetConnectionString("BaseMediatorConnectionString"));
            });
            return services;
        }
    }
}
