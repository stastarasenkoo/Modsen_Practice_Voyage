using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.Business.Services
{
    internal class TicketService : ITicketService
    {
        private readonly ITicketRepository repository;
        public TicketService(ITicketRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<TicketShortInfoResponse>?> GetAsync(int page, GetTicketsRequest request, CancellationToken cancellationtoket)
        {
            return await repository.GetAsync(page, request, cancellationtoket);
        }

        public async Task<TicketDetailsResponse?> GetTicketDetailsAsync(GetTicketDetailsRequest request)
        {
            return await repository.GetTicketDetailsAsync(request);
        }

        public async Task<TicketDetailsResponse> CreateAsync(CreateTicketRequest request)
        {
            var ticket = await repository.CreateAsync(request);

            return ticket;
        }

        public async Task<bool> DeleteAsync(DeleteTicketRequest request)
        {
            return await repository.DeleteAsync(request);
        }
    }
}
