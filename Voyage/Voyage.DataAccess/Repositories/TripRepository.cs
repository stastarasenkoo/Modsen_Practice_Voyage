using Mapster;
using Microsoft.EntityFrameworkCore;
using Voyage.Common.Constants;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Infrastructure;
using Voyage.DataAccess.Repositories.Interfaces;
using Voyage.Common.RequestModels.Trip;

namespace Voyage.DataAccess.Repositories
{
    internal class TripRepository : ITripRepository
    {
        private readonly ApplicationDbContext context;

        public TripRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<TripDetailsResponse> CreateAsync(CreateTripRequest request, CancellationToken cancellationToken)
        {
            var trip = request.Adapt<Trip>();

            trip = context.Trips.Add(trip).Entity;

            await context.SaveChangesAsync(cancellationToken);

            return trip.Adapt<TripDetailsResponse>();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var trip = await context.Trips.FindAsync(new object[] { id }, cancellationToken);

            if (trip is null)
            {
                return false;
            }

            var state = context.Trips.Remove(trip).State;

            await context.SaveChangesAsync(cancellationToken);

            return state == EntityState.Deleted;
        }

        public async Task<TripDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken)
        {
            var trip = await context.Trips
              .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

            var driver = await context.Users
                .FirstOrDefaultAsync(u => u.Id == trip.Id, cancellationToken);

            var route = await context.Routes
                .FirstOrDefaultAsync(d => d.Id == trip.RouteId, cancellationToken);

            var tripDetails = trip.Adapt<TripDetailsResponse>();
            tripDetails.DriverName = driver.FirstName;
            tripDetails.RouteName = route.Name;

            return tripDetails;
        }

        public async Task<IEnumerable<TripShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken)
        {
            page = page <= 0 ? PaginationConstants.StartPage : page;

            return  await context.Trips
                .OrderBy(r => r.Id)
                .Skip((page - PaginationConstants.PageStep) * PaginationConstants.PageSize)
                .Take(PaginationConstants.PageSize)
                .ProjectToType<TripShortInfoResponse>()
                .ToListAsync(cancellationToken);
        }

        public async Task<TripDetailsResponse?> UpdateAsync(UpdateTripRequest request, CancellationToken cancellationToken)
        {
            var trip = request.Adapt<Trip>();

            trip = context.Trips.Update(trip).Entity;

            await context.SaveChangesAsync(cancellationToken);

            return trip.Adapt<TripDetailsResponse>();
        }
    }
}
