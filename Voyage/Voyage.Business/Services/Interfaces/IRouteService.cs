using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.Business.Services.Interfaces
{
    public interface IRouteService
    {
        Task<RouteDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken);

        Task<IEnumerable<RouteDetailsResponse>> FindByNameAsync(string name, CancellationToken cancellationToken);

        Task<IEnumerable<RouteShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken);

        Task<RouteDetailsResponse> CreateAsync(CreateRouteRequest request, CancellationToken cancellationToken);

        Task<RouteDetailsResponse?> UpdateAsync(UpdateRouteRequest request, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
