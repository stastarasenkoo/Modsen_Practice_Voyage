using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface ITransportRepository
    {
        Task<TransportDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken);

        Task<IEnumerable<TransportShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken);

        Task<TransportDetailsResponse> CreateAsync(CreateTransportRequest request, CancellationToken cancellationToken);

        Task<TransportDetailsResponse?> UpdateAsync(UpdateTransportRequest request, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
