using Mapster;
using Microsoft.EntityFrameworkCore;
using Voyage.Common.Constants;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Infrastructure;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DataAccess.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDbContext context;

        public PassengerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PassengerShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken)
        {
            page = page <= 0 ? PaginationConstants.StartPage : page;

            return await context.Passengers
                .Skip((page - PaginationConstants.PageStep) * PaginationConstants.PageSize)
                .Take(PaginationConstants.PageSize)
                .ProjectToType<PassengerShortInfoResponse>()
                .ToListAsync(cancellationToken);
        }

        public async Task<PassengerDetailsResponse?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Passengers
               .ProjectToType<PassengerDetailsResponse>()
               .FirstOrDefaultAsync(r => r.UserId == id, cancellationToken);
        }

        public async Task<PassengerDetailsResponse> CreateAsync(CreatePassengerRequest request, CancellationToken cancellationToken)
        {
            var passenger = request.Adapt<Passenger>();

            passenger = context.Passengers.Add(passenger).Entity;

            await context.SaveChangesAsync(cancellationToken);

            return passenger.Adapt<PassengerDetailsResponse>();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var passenger = await context.Passengers.FindAsync(new object[] { id }, cancellationToken);

            if (passenger is null)
            {
                return false;
            }

            var state = context.Passengers.Remove(passenger).State;

            await context.SaveChangesAsync(cancellationToken);

            return state == EntityState.Deleted;
        }

        public async Task<PassengerDetailsResponse?> UpdateAsync(UpdatePassengerRequest request, CancellationToken cancellationToken)
        {
            if (request is null || request.Points <= 0)
            {
                return null;
            }

            var passenger = await context.Passengers
               .ProjectToType<PassengerDetailsResponse>()
               .FirstOrDefaultAsync(r => r.UserId == request.UserId, cancellationToken);

            if (passenger is null)
            {
                return null;
            }

            passenger.Points = request.Points;

            return passenger;
        }
    }
}
