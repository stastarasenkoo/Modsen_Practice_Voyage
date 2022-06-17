using Mapster;
using Voyage.Common.DTO;
using Voyage.Business.Services.Interfaces;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.Business.Services
{
    internal class TransportTypeService : ITransportTypeService
    {
        private readonly ITransportTypeRepository repository;

        public TransportTypeService(ITransportTypeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<TransportTypeDto>> GetAllAsync()
        {
            var transportsDto = await repository.GetAsync();

            return transportsDto.Adapt<IEnumerable<TransportTypeDto>>();
        }

        public async Task<TransportTypeDto> GetByIdAsync(int id)
        {
            var transportDto = await repository.FindAsync(id);

            return transportDto.Adapt<TransportTypeDto>();
        }

        public async Task CreateAsync(TransportTypeDto transport)
        {
            var transportEntitie = transport.Adapt<TransportType>();

            await repository.CreateAsync(transportEntitie);
        }

        public async Task UpdateAsync(TransportTypeDto transport)
        {
            var transportEntitie = transport.Adapt<TransportType>();

            await repository.UpdateAsync(transportEntitie);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }
    }
}
