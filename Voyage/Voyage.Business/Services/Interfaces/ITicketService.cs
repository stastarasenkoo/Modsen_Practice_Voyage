﻿using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.Business.Services.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDetailsResponse?> GetTicketDetailsAsync(GetTicketDetailsRequest request);

        Task<IEnumerable<TicketShortInfoResponse>?> GetAsync(int page, GetTicketsRequest request, CancellationToken cancellationtoken);

        Task<TicketDetailsResponse> CreateAsync(CreateTicketRequest request, CancellationToken cancellationtoken);

        Task<bool> DeleteAsync(DeleteTicketRequest request, CancellationToken cancellationtoken);
    }
}
