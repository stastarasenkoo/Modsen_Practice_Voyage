using Mapster;
using Microsoft.EntityFrameworkCore;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Infrastructure;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DataAccess.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext context;

        public TicketRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<TicketDetailsResponse> CreateAsync(CreateTicketRequest request)
        {
            var ticket = request.Adapt<Ticket>();

            ticket = context.Tickets.Add(ticket).Entity;

            await context.SaveChangesAsync();

            return ticket.Adapt<TicketDetailsResponse>();
        }

        public async Task<bool> DeleteAsync(DeleteTicketRequest request)
        {
            var ticket = await context.Tickets.FindAsync(request.PassengerId,request.TripId);
            
            if (ticket is null)
            {
                return false;
            }

            var state = context.Tickets.Remove(ticket).State;

            await context.SaveChangesAsync();

            return state == EntityState.Deleted;
        }

        public async Task<IEnumerable<TicketShortInfoResponse>> GetAsync(GetTicketsRequest request)
        {
            if (request.PassengerId is null)
            {
                if (request.TripId is null)
                {
                    return await Task.Run(() =>
                    {
                        return context.Tickets.ProjectToType<TicketShortInfoResponse>();
                    });
                }
                else
                {
                    return await Task.Run(() =>
                    {
                        return context.Tickets.ProjectToType<TicketShortInfoResponse>().Where(p => p.TripId == request.TripId);
                    });
                }
            }
            else
            {
                return await Task.Run(() =>
                {
                    return context.Tickets.ProjectToType<TicketShortInfoResponse>().Where(p => p.PassengerId == request.PassengerId);
                });
            }
        }

        public async Task<TicketDetailsResponse> GetTicketDetailsAsync(GetTicketDetailsRequest request)
        {
            var ticket = await context.Tickets.FindAsync(request.PassengerId, request.TripId);

            return ticket.Adapt<TicketDetailsResponse>();
        }
    }
}
