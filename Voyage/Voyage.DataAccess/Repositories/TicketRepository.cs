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

        public async Task<IEnumerable<TicketShortInfoResponse>?> GetAsync(GetTicketsRequest request, CancellationToken cancellationtoket)
        {
            if (request.PassengerId is null && request.TripId is null)
            {
                return await Task.Run(() =>
                {
                    var ticketinfo = context.Tickets.ProjectToType<TicketShortInfoResponse>();
                    var tripinfo = context.Trips.ProjectToType<Trip>();
                    var routeinfo = context.Routes.ProjectToType<Route>();

                    if (ticketinfo is null || tripinfo is null || routeinfo is null)
                    {
                        return null;
                    }

                    var tripandrouteinfo = tripinfo.Join(routeinfo,
                        trip => trip.RouteId,
                        route => route.Id,
                        (trip, route) => new
                        {
                            TripId = trip.Id,
                            TripDate = trip.DepartureTime,
                            Price = trip.FinalPrice,
                            RouteName = route.Name
                        });

                    var ticketandtripandrouteinfo = tripandrouteinfo.Join(ticketinfo,
                        tripandroute => tripandroute.TripId,
                        ticket => ticket.TripId,
                        (tripandroute, ticket) => new
                        {
                            TripId = tripandroute.TripId,
                            PassengerId = ticket.PassengerId,
                            RouteName = tripandroute.RouteName,
                            TripDate = tripandroute.TripDate,
                            Price = tripandroute.Price
                        });

                    var result = ticketandtripandrouteinfo.ProjectToType<TicketShortInfoResponse>();

                    if (result is null)
                    {
                        return null;
                    }

                    return result.ToListAsync(cancellationtoket);
                });
            }

            Func<TicketShortInfoResponse, bool> function = (request.PassengerId is null) ?
            (p => p.TripId == request.TripId) :
            (p => p.PassengerId == request.PassengerId);

            var ticketinfo = context.Tickets.ProjectToType<TicketShortInfoResponse>().Where(function);
            var tripinfo = context.Trips.ProjectToType<Trip>();
            var routeinfo = context.Routes.ProjectToType<Route>();

            if (ticketinfo is null || tripinfo is null || routeinfo is null)
            {
                return null;
            }

            var tripandrouteinfo = tripinfo.Join(routeinfo,
                trip => trip.RouteId,
                route => route.Id,
                (trip, route) => new
                {
                    TripId = trip.Id,
                    TripDate = trip.DepartureTime,
                    Price = trip.FinalPrice,
                    RouteName = route.Name
                });

            var ticketandtripandrouteinfo = tripandrouteinfo.Join(ticketinfo,
                tripandroute => tripandroute.TripId,
                ticket => ticket.TripId,
                (tripandroute, ticket) => new
                {
                    TripId = tripandroute.TripId,
                    PassengerId = ticket.PassengerId,
                    RouteName = tripandroute.RouteName,
                    TripDate = tripandroute.TripDate,
                    Price = tripandroute.Price
                });

            var result = ticketandtripandrouteinfo.ProjectToType<TicketShortInfoResponse>();

            if (result is null)
            {
                return null;
            }

            return result;
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

            var result = ticket.Adapt<TicketDetailsResponse>();
            result.TripShortInfo = trip.Adapt<TripShortInfoResponse>();
            result.PassengerName = passenger.FirstName;

            return result;
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
    }
}
