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

        public async Task<TicketDetailsResponse> CreateAsync(TicketDto ticketDto)
        {
            var ticket = await repository.CreateAsync(ticketDto);

            return ticket;
        }

        public Task<bool> Delete(DeleteTicketRequest request)
        {
            return repository.Delete(request);
        }

        public async Task<IEnumerable<TicketDto>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<IEnumerable<TicketShortInfoResponse>> GetByPassengerIdAsync(int passengerId)
        {
            return await repository.GetByPassengerIdAsync(passengerId);
        }

        public async Task<IEnumerable<TicketShortInfoResponse>> GetByTripIdAsync(int tripId)
        {
            return await repository.GetByTripIdAsync(tripId);
        }

        public async Task<TicketDetailsResponse> GetTicketDetailsAsync(GetTicketDetailsRequest request)
        {
            return await repository.GetTicketDetailsAsync(request);
        }
    }
}
