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
        
        public async Task<RouteDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken)
        {
            var route = await repository.FindAsync(id, cancellationToken);

            return route;
        }

        public async Task<IEnumerable<RouteDetailsResponse>> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await repository.FindByNameAsync(name, cancellationToken);
        }

        public async Task<IEnumerable<RouteShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken)
        {
            return await repository.GetAsync(page, cancellationToken);
        }

        public async Task<RouteDetailsResponse> CreateAsync(CreateRouteRequest request, CancellationToken cancellationToken)
        {
            var route = await repository.CreateAsync(request, cancellationToken);

            return route;
        }

        public async Task<RouteDetailsResponse?> UpdateAsync(UpdateRouteRequest request, CancellationToken cancellationToken)
        {
            var transport = await repository.UpdateAsync(request, cancellationToken);

            return transport;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            return await repository.DeleteAsync(id, cancellationToken);
        }
    }
}
