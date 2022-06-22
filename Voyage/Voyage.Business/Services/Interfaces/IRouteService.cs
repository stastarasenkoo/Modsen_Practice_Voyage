using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.Business.Services.Interfaces
{
    public interface IRouteService
    {
        Task<RouteDetailsResponse?> FindAsync(int id);

        Task<IEnumerable<RouteShortInfoResponse>> GetAsync(int page);

        Task<IEnumerable<RouteDetailsResponse>> FindByNameAsync(string name);

        Task<RouteDetailsResponse> CreateAsync(CreateRouteRequest request);

        Task<RouteDetailsResponse?> UpdateAsync(UpdateRouteRequest request);

        Task<bool> DeleteAsync(int id);
    }
}
