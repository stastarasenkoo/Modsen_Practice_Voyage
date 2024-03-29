﻿using Voyage.Common.Dtos;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<TicketDetailsResponse?> GetTicketDetailsAsync(GetTicketDetailsRequest request);

        Task<IEnumerable<TicketShortInfoResponse>?> GetAsync(int page, GetTicketsRequest request, CancellationToken cancellationtoken);

        Task<TicketDetailsResponse> CreateAsync(CreateTicketRequest request, CancellationToken cancellationtoken);

        Task<bool> DeleteAsync(DeleteTicketRequest request, CancellationToken cancellationtoken);
    }
}
