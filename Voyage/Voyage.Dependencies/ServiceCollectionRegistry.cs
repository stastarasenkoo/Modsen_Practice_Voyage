using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Voyage.Business.Helpers;
using Voyage.Common.Settings;
using Voyage.DataAccess.Helpers;

namespace Voyage.Dependencies
{
    public static class ServiceCollectionRegistry
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services,
            Action<OptionsBuilder<DatabaseConfigs>> configureOptions)
        {
            configureOptions.Invoke(services.AddOptions<DatabaseConfigs>());
            services.AddApplicationDbContext().AddRepositories();

            return services;
        }

        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddServices();
            services.AddValidators();

            return services;
        }
    }
}