using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.Business.Services
{
    internal class RouteService : IRouteService
    {
        private readonly IRouteRepository repository;

        public RouteService(IRouteRepository repository)
        {
            this.repository = repository;
        }
        public async Task<RouteDetailsResponse> CreateAsync(CreateRouteRequest request)
        {
            var route = await repository.CreateAsync(request);

            return route;
        }

        public async Task<RouteDetailsResponse?> FindAsync(int id)
        {
            var route = await repository.FindAsync(id);

            return route;
        }

        public async Task<IEnumerable<RouteShortInfoResponse>> GetAsync(int page)
        {
            return await repository.GetAsync(page);
        }

        public async Task<IEnumerable<RouteDetailsResponse>> FindByNameAsync(string name)
        {
            return await repository.FindByNameAsync(name);
        }

        public async Task<RouteDetailsResponse?> UpdateAsync(UpdateRouteRequest request)
        {
            var transport = await repository.UpdateAsync(request);

            return transport;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
