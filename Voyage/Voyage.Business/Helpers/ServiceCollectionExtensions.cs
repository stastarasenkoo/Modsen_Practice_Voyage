using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Voyage.Business.Services;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.Settings;
using Voyage.DataAccess.Entities;

namespace Voyage.Business.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITransportService, TransportService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRouteService, RouteService>();

            return services;
        }

        public static IServiceCollection AddIdentityService(this IServiceCollection services, DatabaseConfigs database)
        {
            services
                .AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<AppUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(database.ConnectionString,
                        sql => sql.MigrationsAssembly("Voyage.DataAccess"));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(database.ConnectionString,
                       sql => sql.MigrationsAssembly("Voyage.DataAccess"));
                });

            return services;
        }
    }
}
