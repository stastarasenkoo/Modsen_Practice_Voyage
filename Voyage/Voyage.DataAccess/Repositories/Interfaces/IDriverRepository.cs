using Voyage.Common.RequestModels.Driver;
using Voyage.Common.ResponseModels;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface IDriverRepository
    {
        Task<DriverDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken);

        Task<IEnumerable<DriverDetailsResponse>> FindByNameAsync(string name, CancellationToken cancellationToken);

        Task<IEnumerable<DriverShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken);

        Task<DriverDetailsResponse> CreateAsync(CreateDriverRequest request, CancellationToken cancellationToken);

        Task<DriverDetailsResponse?> UpdateAsync(UpdateDriverRequest request, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
