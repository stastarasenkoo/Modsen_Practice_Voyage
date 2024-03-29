﻿using Voyage.Business.Services.Interfaces;
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

        public async Task<IEnumerable<TicketShortInfoResponse>?> GetAsync(int page, GetTicketsRequest request, CancellationToken cancellationtoken)
        {
            return await repository.GetAsync(page, request, cancellationtoken);
        }

        public async Task<TicketDetailsResponse?> GetTicketDetailsAsync(GetTicketDetailsRequest request)
        {
            return await repository.GetTicketDetailsAsync(request);
        }

        public async Task<TicketDetailsResponse> CreateAsync(CreateTicketRequest request, CancellationToken cancellationtoken)
        {
            var ticket = await repository.CreateAsync(request, cancellationtoken);

            return ticket;
        }

        public async Task<bool> DeleteAsync(DeleteTicketRequest request, CancellationToken cancellationtoken)
        {
            return await repository.DeleteAsync(request, cancellationtoken);
        }
    }
}
