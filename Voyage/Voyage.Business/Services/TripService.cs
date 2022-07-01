using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels.Trip;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.Business.Services
{
    internal class TripService : ITripService
    {
        private readonly ITripRepository repository;

        public TripService(ITripRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TripDetailsResponse> CreateAsync(CreateTripRequest request, CancellationToken cancellationToken)
        {
            var trip = await repository.CreateAsync(request, cancellationToken);

            return trip;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var isDeleted = await repository.DeleteAsync(id, cancellationToken);

            return isDeleted;
        }

        public async Task<TripDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken)
        {
            var trip = await repository.FindAsync(id, cancellationToken);

            return trip;
        }

        public async Task<IEnumerable<TripShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken)
        {
            return await repository.GetAsync(page, cancellationToken);
        }

        public async Task<TripDetailsResponse?> UpdateAsync(UpdateTripRequest request, CancellationToken cancellationToken)
        {
            var trip = await repository.UpdateAsync(request, cancellationToken);

            return trip;
        }
    }
}
