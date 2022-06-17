using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Voyage.Business.Helpers;
using Voyage.Business.Services;
using Voyage.Business.Services.Interfaces;
using Voyage.DataAccess.Helpers;
using Voyage.DataAccess.Settings;

namespace Voyage.Dependencies
{
    public static class ServiceCollectionRegistry
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseConfigs>(configuration.GetSection(nameof(DatabaseConfigs)));

            services.AddApplicationDbContext()
                .AddRepositories();
        }

        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddServices();
        }
    }
}