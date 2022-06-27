using FluentValidation;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.Business.Services
{
    internal class TransportService : ITransportService
    {
        private readonly ITransportRepository repository;
        private readonly IValidator<CreateTransportRequest> createRequestValidator;
        private readonly IValidator<UpdateTransportRequest> updateRequestValidator;

        public TransportService(
            ITransportRepository repository,
            IValidator<CreateTransportRequest> createRequestValidator,
            IValidator<UpdateTransportRequest> updateRequestValidator)
        {
            this.repository = repository;
            this.createRequestValidator = createRequestValidator;
            this.updateRequestValidator = updateRequestValidator;
        }

        public async Task<TransportDetailsResponse> CreateAsync(CreateTransportRequest request)
        {
            await createRequestValidator.ValidateAsync(request);
            var transport = await repository.CreateAsync(request);

            return transport;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var isDeleted = await repository.DeleteAsync(id);

            return isDeleted;
        }

        public async Task<TransportDetailsResponse?> FindAsync(int id)
        {
            var transport = await repository.FindAsync(id);

            return transport;
        }

        public async Task<IEnumerable<TransportShortInfoResponse>> GetAsync()
        {
            var transports = await repository.GetAsync();

            return transports;
        }

        public async Task<TransportDetailsResponse?> UpdateAsync(UpdateTransportRequest request)
        {
            await updateRequestValidator.ValidateAsync(request);
            var transport = await repository.UpdateAsync(request);

            return transport;
        }
    }
}
