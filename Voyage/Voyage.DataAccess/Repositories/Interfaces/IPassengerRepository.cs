using Voyage.Common.RequestModels.Passenger;
using Voyage.Common.ResponseModels;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface IPassengerRepository
    {
        Task<PassengerDetailsResponse?> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<IEnumerable<PassengerShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken);

        Task<PassengerDetailsResponse> CreateAsync(PassengerRequest request, CancellationToken cancellationToken);

        Task<PassengerDetailsResponse?> UpdateAsync(PassengerRequest request, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
