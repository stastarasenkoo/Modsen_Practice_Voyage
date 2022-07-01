using Mapster;
using Microsoft.EntityFrameworkCore;
using Voyage.Common.Constants;
using Voyage.Common.RequestModels.Ticket;
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

        public async Task<IEnumerable<TicketShortInfoResponse>?> GetAsync(int page, TicketSearchRequest request, CancellationToken cancellationtoken)
        {
            page = page <= 0 ? PaginationConstants.StartPage : page;

            if (request.PassengerId is null && request.TripId is null)
            {
                    var ticketInfoToNullParameters = context.Tickets
                    .Skip((page - PaginationConstants.PageStep) * PaginationConstants.PageSize)
                    .Take(PaginationConstants.PageSize)
                    .ProjectToType<TicketShortInfoResponse>();
                    var tripInfoToNullParameters = context.Trips.ProjectToType<Trip>();
                    var routeInfoToNullParameters = context.Routes.ProjectToType<Route>();

                    if (ticketInfoToNullParameters is null || tripInfoToNullParameters is null || routeInfoToNullParameters is null)
                    {
                        return null;
                    }

                    var tripAndRouteInfoToNullParameters = tripInfoToNullParameters.Join(routeInfoToNullParameters,
                        trip => trip.RouteId,
                        route => route.Id,
                        (trip, route) => new
                        {
                            TripId = trip.Id,
                            TripDate = trip.DepartureTime,
                            Price = trip.FinalPrice,
                            RouteName = route.Name
                        });

                    var ticketAndTripAndRouteInfoToNullParameters = tripAndRouteInfoToNullParameters.Join(ticketInfoToNullParameters,
                        tripAndRouteToNullParameters => tripAndRouteToNullParameters.TripId,
                        ticket => ticket.TripId,
                        (tripAndRouteToNullParameters, ticket) => new
                        {
                            TripId = tripAndRouteToNullParameters.TripId,
                            PassengerId = ticket.PassengerId,
                            RouteName = tripAndRouteToNullParameters.RouteName,
                            TripDate = tripAndRouteToNullParameters.TripDate,
                            Price = tripAndRouteToNullParameters.Price
                        });

                    var resultToNullParameters = ticketAndTripAndRouteInfoToNullParameters.ProjectToType<TicketShortInfoResponse>();

                    if (resultToNullParameters is null)
                    {
                        return null;
                    }

                    return await resultToNullParameters.ToListAsync(cancellationtoken);
            }

            Func<TicketShortInfoResponse, bool> function = (request.PassengerId is null) ?
            (p => p.TripId == request.TripId) :
            (p => p.PassengerId == request.PassengerId);

            var ticketInfoToNotNullParameters = context.Tickets
                .Skip((page - PaginationConstants.PageStep) * PaginationConstants.PageSize)
                .Take(PaginationConstants.PageSize)
                .ProjectToType<TicketShortInfoResponse>();
            var tripInfoToNotNullParameters = context.Trips.ProjectToType<Trip>();
            var routeInfoToNotNullParameters = context.Routes.ProjectToType<Route>();

            if (ticketInfoToNotNullParameters is null || tripInfoToNotNullParameters is null || routeInfoToNotNullParameters is null)
            {
                return null;
            }

            var tripAndRouteInfoToNotNullParameters = tripInfoToNotNullParameters.Join(routeInfoToNotNullParameters,
                trip => trip.RouteId,
                route => route.Id,
                (trip, route) => new
                {
                    TripId = trip.Id,
                    TripDate = trip.DepartureTime,
                    Price = trip.FinalPrice,
                    RouteName = route.Name
                });

            var ticketAndTripAndRouteInfoToNotNullParameters = tripAndRouteInfoToNotNullParameters.Join(ticketInfoToNotNullParameters,
                tripAndRouteToNotNullParameters => tripAndRouteToNotNullParameters.TripId,
                ticket => ticket.TripId,
                (tripAndRouteToNotNullParameters, ticket) => new
                {
                    TripId = tripAndRouteToNotNullParameters.TripId,
                    PassengerId = ticket.PassengerId,
                    RouteName = tripAndRouteToNotNullParameters.RouteName,
                    TripDate = tripAndRouteToNotNullParameters.TripDate,
                    Price = tripAndRouteToNotNullParameters.Price
                });

            var resultToNotNullParameters = ticketAndTripAndRouteInfoToNotNullParameters.ProjectToType<TicketShortInfoResponse>();

            if (resultToNotNullParameters is null)
            {
                return null;
            }

            return await resultToNotNullParameters.ToListAsync(cancellationtoken);
        }

        public async Task<TicketDetailsResponse?> GetTicketDetailsAsync(TicketRequest request)
        {
            if (request is null)
            {
                return null;
            }

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

        public async Task<TicketDetailsResponse> CreateAsync(TicketRequest request, CancellationToken cancellationtoken)
        {
            var ticket = request.Adapt<Ticket>();

            ticket = context.Tickets.Add(ticket).Entity;

            await context.SaveChangesAsync(cancellationtoken);

            return ticket.Adapt<TicketDetailsResponse>();
        }

        public async Task<bool> DeleteAsync(TicketRequest request, CancellationToken cancellationtoken)
        {
            var ticket = await context.Tickets.FindAsync(request.PassengerId,request.TripId);
            
            if (ticket is null)
            {   
                return false;
            }

            var state = context.Tickets.Remove(ticket).State;

            await context.SaveChangesAsync(cancellationtoken);

            return state == EntityState.Deleted;
        }
    }
}
