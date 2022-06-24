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

        public async Task<RouteDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Routes
                .ProjectToType<RouteDetailsResponse>()
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<RouteDetailsResponse>> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await context.Routes
                .Where(r => r.Name.Contains(name))
                .OrderBy(r => r.Name)
                .ProjectToType<RouteDetailsResponse>()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<RouteShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken)
        {
            page = page <= 0 ? PaginationConstants.StartPage : page;

            return await context.Routes
                .OrderBy(r => r.Id)
                .Skip((page - PaginationConstants.PageStep) * PaginationConstants.PageSize)
                .Take(PaginationConstants.PageSize)
                .ProjectToType<RouteShortInfoResponse>()
                .ToListAsync(cancellationToken);
        }

        public async Task<RouteDetailsResponse> CreateAsync(CreateRouteRequest request, CancellationToken cancellationToken)
        {
            var route = request.Adapt<Route>();

            route = context.Routes.Add(route).Entity;

            await context.SaveChangesAsync(cancellationToken);

            return route.Adapt<RouteDetailsResponse>();
        }

        public async Task<RouteDetailsResponse?> UpdateAsync(UpdateRouteRequest request, CancellationToken cancellationToken)
        {
            var route = request.Adapt<Route>();

            route = context.Routes.Update(route).Entity;

            await context.SaveChangesAsync(cancellationToken);

            return route.Adapt<RouteDetailsResponse>();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var route = await context.Routes.FindAsync(new object[] { id }, cancellationToken);

            if (route is null)
            {
                return false;
            }

            var state = context.Routes.Remove(route).State;

            await context.SaveChangesAsync(cancellationToken);

            return state == EntityState.Deleted;
        }
    }
}
