using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Infrastructure;
using Voyage.DataAccess.Repositories;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DataAccess.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>()
                .AddIdentity<AppUser, IdentityRole<int>>(options =>
                {
                    options.Password.RequiredLength = 1;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                })
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services..AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITransportRepository, TransportRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();

            services.AddScoped<IPassengerRepository, PassengerRepository>();

            services.AddScoped<IDriverRepository, DriverRepository>();

            return services;
        }
    }
}
