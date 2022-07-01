using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels.Transport;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.Business.Services
{
    internal class TransportService : ITransportService
    {
        private readonly ITransportRepository repository;

        public TransportService(ITransportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TransportDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken)
        {
            var transport = await repository.FindAsync(id, cancellationToken);

            return transport;
        }

        public async Task<IEnumerable<TransportShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken)
        {
            return await repository.GetAsync(page, cancellationToken);
        }

        public async Task<TransportDetailsResponse> CreateAsync(CreateTransportRequest request, CancellationToken cancellationToken)
        {
            var transport = await repository.CreateAsync(request, cancellationToken);

            return transport;
        }

        public async Task<TransportDetailsResponse?> UpdateAsync(UpdateTransportRequest request, CancellationToken cancellationToken)
        {
            var transport = await repository.UpdateAsync(request, cancellationToken);

            return transport;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var isDeleted = await repository.DeleteAsync(id, cancellationToken);

            return isDeleted;
        }
    }
}
