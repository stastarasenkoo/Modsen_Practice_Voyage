using Voyage.Common.Dtos;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<TicketDetailsResponse> GetTicketDetailsAsync(GetTicketDetailsRequest request);

        Task<IEnumerable<TicketShortInfoResponse>> GetAsync(GetTicketsRequest request);

        Task<TicketDetailsResponse> CreateAsync(CreateTicketRequest request);

        Task<bool> DeleteAsync(DeleteTicketRequest request);
    }
}
