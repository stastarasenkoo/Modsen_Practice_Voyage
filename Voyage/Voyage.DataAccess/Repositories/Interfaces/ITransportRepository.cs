using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface ITransportRepository
    {
        Task<TransportDetailsResponse?> FindAsync(int id);

        Task<IEnumerable<TransportShortInfoResponse>> GetAsync();

        Task<TransportDetailsResponse> CreateAsync(CreateTransportRequest request);

        Task<TransportDetailsResponse?> UpdateAsync(UpdateTransportRequest request);

        Task<bool> DeleteAsync(int id);
    }
}
