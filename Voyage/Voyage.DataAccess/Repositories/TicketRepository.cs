using Mapster;
using Voyage.Common.Dtos;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.EntityKeys;
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

        public async Task<TicketDto> CreateAsync(TicketDto ticketDto)
        {
            var ticket = ticketDto.Adapt<Ticket>();

            ticket = (await context.Tickets.AddAsync(ticket)).Entity;
            await context.SaveChangesAsync();

            return ticket.Adapt<TicketDto>();
        }

        public async Task<bool> DeleteAsync(TicketKey key)
        {
            var ticket = await context.Tickets.FindAsync(key.TripId, key.PassengerId);

            if (ticket is null)
            {
                return false;
            }

            context.Tickets.Remove(ticket);

            return (await context.SaveChangesAsync()) > 0;
        }

        public async Task<TicketDto?> FindAsync(TicketKey key)
        {
            var ticket = await context.Tickets.FindAsync(key.TripId, key.PassengerId);

            return ticket is null ? null : ticket.Adapt<TicketDto>();
        }

        public async Task<IEnumerable<TicketDto>> GetAsync()
        {
            return await Task.Run(() =>
            {
                var tickets = context.Tickets.Take(1).ProjectToType<TicketDto>();

                return tickets;
            });
        }

        public async Task<TicketDto> UpdateAsync(TicketDto ticketDto)
        {
            var ticket = ticketDto.Adapt<Ticket>();
            ticket = context.Tickets.Update(ticket).Entity;

            await context.SaveChangesAsync();

            return ticket.Adapt<TicketDto>();
        }
    }
}
