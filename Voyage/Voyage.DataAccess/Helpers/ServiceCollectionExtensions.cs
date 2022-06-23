using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Voyage.Common.Entities;
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
                .AddIdentity<AppUser, IdentityRole<int>>()
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITransportRepository, TransportRepository>();

            return services;
        }
    }
}
