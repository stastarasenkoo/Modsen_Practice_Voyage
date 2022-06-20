using Voyage.Common.Dtos;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.Business.Services.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDetailsResponse> GetTicketDetailsAsync(GetTicketDetailsRequest request);

        Task<IEnumerable<TicketShortInfoResponse>> GetByPassengerIdAsync(int passengerId);

        Task<IEnumerable<TicketShortInfoResponse>> GetByTripIdAsync(int tripId);

        Task<IEnumerable<TicketDto>> GetAsync();

        Task<TicketDetailsResponse> CreateAsync(TicketDto ticketDto);

        Task<bool> Delete(DeleteTicketRequest request);
    }
}
