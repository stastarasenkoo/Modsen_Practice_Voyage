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
            if (request.PassengerId is null && request.TripId is null)
            {
                    return await Task.Run(() =>
                    {
                        var ticketinfo = context.Tickets.ProjectToType<TicketShortInfoResponse>();
                        var tripinfo = context.Trips.ProjectToType<TicketShortInfoResponse>();
                        var routeinfo = context.Routes.ProjectToType<TicketShortInfoResponse>();

                        //if(ticketinfo is null || tripinfo is null || routeinfo is null)
                        //{
                        //    return null;
                        //}

                        var ticketandtripinfo =
                        from trip in tripinfo
                        join ticket in ticketinfo on trip.PassengerId equals ticket.PassengerId
                        select new { TripId = ticket.TripId, PassengerId = ticket.PassengerId, TripDate = trip.TripDate, Price = trip.Price, RouteName = ticket.RouteName };

                        var finalresult =
                        from route in routeinfo
                        join ticketandtrip in ticketandtripinfo on route.RouteName equals ticketandtrip.RouteName
                        select new { TripId = ticketandtrip.TripId, PassengerId = ticketandtrip.PassengerId, TripDate = ticketandtrip.TripDate, Price = ticketandtrip.Price, RouteName = route.RouteName };


                        ticketinfo.Adapt<TicketShortInfoResponse>();

                        return ticketinfo;
                    });
            }
            else if (request.PassengerId is null)
            {
                return await Task.Run(() =>
                {
                    return context.Tickets.ProjectToType<TicketShortInfoResponse>().Where(p => p.TripId == request.TripId);
                });
            }
            else
            {
                return await Task.Run(() =>
                {
                    return context.Tickets.ProjectToType<TicketShortInfoResponse>().Where(p => p.PassengerId == request.PassengerId);
                });
            }
        }

        public async Task<TicketDetailsResponse?> GetTicketDetailsAsync(GetTicketDetailsRequest request)
        {
            var ticket = await context.Tickets.FindAsync(request.PassengerId, request.TripId);
            var trip = await context.Trips.FindAsync(request.TripId);
            var passenger = await context.Users.FindAsync(request.PassengerId);


            if (ticket is null || trip is null || passenger is null)
            {
                return null;
            }

            var result =  ticket.Adapt<TicketDetailsResponse>();
            result.TripShortInfo = trip.Adapt<TripShortInfoResponse>();
            result.PassengerName = passenger.FirstName;
            return result;
        }
    }
}
