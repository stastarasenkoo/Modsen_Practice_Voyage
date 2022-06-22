using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface IRouteRepository
    {
        Task<RouteDetailsResponse?> FindAsync(int id);

        Task<IEnumerable<RouteDetailsResponse>> FindByNameAsync(string name);

        Task<IEnumerable<RouteShortInfoResponse>> GetAsync(int page);

        Task<RouteDetailsResponse> CreateAsync(CreateRouteRequest request);

        Task<RouteDetailsResponse?> UpdateAsync(UpdateRouteRequest request);

        Task<bool> DeleteAsync(int id);
    }
}
