using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Voyage.Business.Services;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.Entities;
using Voyage.Common.Settings;

namespace Voyage.Business.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITransportService, TransportService>();

            return services;
        }             
    }
}
