using Voyage.Common.RequestModels.Ticket;
using Voyage.Common.ResponseModels;

namespace Voyage.Business.Services.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDetailsResponse?> GetTicketDetailsAsync(TicketRequest request);

        Task<IEnumerable<TicketShortInfoResponse>?> GetAsync(int page, TicketSearchRequest request, CancellationToken cancellationtoken);

        Task<TicketDetailsResponse> CreateAsync(TicketRequest request, CancellationToken cancellationtoken);

        Task<bool> DeleteAsync(TicketRequest request, CancellationToken cancellationtoken);
    }
}
