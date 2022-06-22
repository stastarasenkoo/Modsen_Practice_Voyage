using Voyage.Business.Services.Interfaces;
using Voyage.Common.Dtos;
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


        public async Task<TicketDetailsResponse> CreateAsync(CreateTicketRequest request)
        {
            var ticket = await repository.CreateAsync(request);

            return ticket;
        }

        public Task<bool> DeleteAsync(DeleteTicketRequest request)
        {
            return repository.DeleteAsync(request);
        }

        public async Task<IEnumerable<TicketShortInfoResponse>> GetAsync(GetTicketsRequest request)
        {
            return await repository.GetAsync(request);
        }

        public async Task<TicketDetailsResponse?> GetTicketDetailsAsync(GetTicketDetailsRequest request)
        {
            return await repository.GetTicketDetailsAsync(request);
        }
    }
}
