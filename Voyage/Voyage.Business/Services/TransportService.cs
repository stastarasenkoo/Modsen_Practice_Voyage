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
            await createRequestValidator.ValidateAsync(request);
            var transport = await repository.CreateAsync(request, cancellationToken);

            return transport;
        }

        public async Task<TransportDetailsResponse?> UpdateAsync(UpdateTransportRequest request, CancellationToken token)
        {
            await updateRequestValidator.ValidateAsync(request);
            var transport = await repository.UpdateAsync(request, token);

            return transport;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var isDeleted = await repository.DeleteAsync(id, cancellationToken);

            return isDeleted;
        }
    }
}
