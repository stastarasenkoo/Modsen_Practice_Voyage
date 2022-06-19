using Voyage.Common.Dtos;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<TicketDetailsResponse> GetTicketDetailsAsync(GetTicketDetailsRequest request);

        Task<IEnumerable<TicketIShortInfoResponse>> GetByPassengerIdAsync(int passengerId);

        Task<IEnumerable<TicketIShortInfoResponse>> GetByTripIdAsync(int tripId);

        Task<IEnumerable<TicketDto>> GetAsync();

        Task<TicketDetailsResponse> CreateAsync(TicketDto ticketDto);

        Task<bool> Delete(DeleteTicketRequest request);
    }
}
