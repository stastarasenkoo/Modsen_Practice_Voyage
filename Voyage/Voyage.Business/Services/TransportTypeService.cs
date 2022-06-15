using AutoMapper;
using Voyage.Business.Models;
using Voyage.Business.Services.Interfaces;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.Business.Services
{
    public class TransportTypeService : ITransportTypeService
    {
        private readonly ITransportTypeRepository repository;


        public TransportTypeService(ITransportTypeRepository repository)
        {
            this.repository = repository;

        }

        public async Task<TransportType?> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task CreateAsync(TransportType transport)
        {
            await repository.CreateAsync(transport);
        }

        public async Task UpdateAsync(TransportType transport)
        {
            await repository.UpdateAsync(transport);
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(id);
        }
    }
}
