using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Voyage.Business.Services;
using Voyage.Business.Services.Interfaces;
using Voyage.DataAccess.Context;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Repositories;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DependencyInjection
{
    public static class ServiceCollectionRegistry
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("Default");
                options.UseSqlServer(connectionString);
            })
                .AddIdentity<AppUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<ITransportTypeRepository, TransportTypeRepository>();
        }
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<ITransportTypeService, TransportTypeService>();
        }
    }
}