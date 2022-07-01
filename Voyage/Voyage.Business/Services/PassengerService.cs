using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels.Passenger;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.Business.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository repository;

        public PassengerService(IPassengerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PassengerShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken)
        {
            return await repository.GetAsync(page, cancellationToken);
        }

        public async Task<PassengerDetailsResponse?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await repository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<PassengerDetailsResponse> CreateAsync(PassengerRequest request, CancellationToken cancellationToken)
        {
            return await repository.CreateAsync(request, cancellationToken);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            return await repository.DeleteAsync(id, cancellationToken);
        }

        public async Task<PassengerDetailsResponse?> UpdateAsync(PassengerRequest request, CancellationToken cancellationToken)
        {
            return await repository.UpdateAsync(request, cancellationToken);
        }
    }
}
