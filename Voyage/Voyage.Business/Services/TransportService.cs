using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels;
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

        public async Task<TransportDetailsResponse> CreateAsync(CreateTransportRequest request)
        {
            var transport = await repository.CreateAsync(request);

            return transport;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await repository.DeleteAsync(id);
        }

        public Task<TransportDetailsResponse?> FindAsync(int id)
        {
            var transport = repository.FindAsync(id);

            return transport;
        }

        public async Task<IEnumerable<TransportShortInfoResponse>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<TransportDetailsResponse?> UpdateAsync(UpdateTransportRequest request)
        {
            var transport = await repository.UpdateAsync(request);

            return transport;
        }
    }
}
