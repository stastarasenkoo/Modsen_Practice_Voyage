using Mapster;
using Microsoft.EntityFrameworkCore;
using Voyage.Common.Constants;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Infrastructure;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DataAccess.Repositories
{
    internal class RouteRepository : IRouteRepository
    {
        private readonly ApplicationDbContext context;

        public RouteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<RouteDetailsResponse> CreateAsync(CreateRouteRequest request)
        {
            var route = request.Adapt<Route>();

            route = context.Routes.Add(route).Entity;

            await context.SaveChangesAsync();

            return route.Adapt<RouteDetailsResponse>();
        }

        public async Task<RouteDetailsResponse?> FindAsync(int id)
        {
            var route = await context.Routes.FindAsync(id);

            return route?.Adapt<RouteDetailsResponse>();
        }

        public async Task<IEnumerable<RouteDetailsResponse>> FindByNameAsync(string name)
        {
            return await Task.Run(() =>
            {
                return context.Routes
                    .Where(r => r.Name.Contains(name))
                    .OrderBy(r => r.Name)
                    .ProjectToType<RouteDetailsResponse>();
            });
        }

        public async Task<IEnumerable<RouteShortInfoResponse>> GetAsync(int page)
        {
            page = page <= 0 ? PaginationConstants.StartPage : page;

            return await Task.Run(() =>
            {
                return context.Routes
                    .OrderBy(r => r.Id)
                    .Skip((page - PaginationConstants.PageStep) * PaginationConstants.PageSize)
                    .Take(PaginationConstants.PageSize)
                    .ProjectToType<RouteShortInfoResponse>();
            });
        }

        public async Task<RouteDetailsResponse?> UpdateAsync(UpdateRouteRequest request)
        {
            var route = request.Adapt<Route>();

            route = context.Routes.Update(route).Entity;

            await context.SaveChangesAsync();

            return route.Adapt<RouteDetailsResponse>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var route = await context.Routes.FindAsync(id);

            if (route is null)
            {
                return false;
            }

            var state = context.Routes.Remove(route).State;

            await context.SaveChangesAsync();

            return state == EntityState.Deleted;
        }
    }
}
