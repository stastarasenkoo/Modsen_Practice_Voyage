using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.Business.Services.Interfaces
{
    public interface ITransportService
    {
        Task<TransportDetailsResponse?> FindAsync(int id);

        Task<IEnumerable<TransportShortInfoResponse>> GetAsync();

        Task<TransportDetailsResponse> CreateAsync(CreateTransportRequest request);

        Task<TransportDetailsResponse?> UpdateAsync(UpdateTransportRequest request);

        Task<bool> DeleteAsync(int id);
    }
}
