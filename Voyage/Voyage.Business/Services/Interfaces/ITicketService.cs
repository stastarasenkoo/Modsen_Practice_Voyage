using Voyage.Common.Dtos;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.Business.Services.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDetailsResponse> GetTicketDetailsAsync(GetTicketDetailsRequest request);

        Task<IEnumerable<TicketShortInfoResponse>> GetAsync(GetTicketsRequest request);

        Task<TicketDetailsResponse> CreateAsync(CreateTicketRequest request);

        Task<bool> DeleteAsync(DeleteTicketRequest request);
    }
}
