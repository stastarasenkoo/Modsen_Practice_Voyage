using Microsoft.EntityFrameworkCore;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Infrastructure;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DataAccess.Repositories
{
    internal class TransportTypeRepository : ITransportTypeRepository
    {
        private readonly ApplicationDbContext appContext;

        public TransportTypeRepository(ApplicationDbContext context)
        {
            appContext = context;
        }

        public async Task<IEnumerable<TransportType>> GetAsync()
        {
            var transportTypes = appContext.TransportTypes.AsNoTracking();

            return await Task.FromResult(transportTypes);
        }

        public async Task<TransportType?> FindAsync(int id)
        {
            return await appContext.TransportTypes.FindAsync(id);
        }

        public async Task<TransportType> CreateAsync(TransportType transport)
        {
            var transportType = (await appContext.TransportTypes.AddAsync(transport)).Entity;

            await appContext.SaveChangesAsync();

            return transportType;
        }

        public async Task<TransportType> UpdateAsync(TransportType transport)
        {
            var transportType = appContext.TransportTypes.Update(transport).Entity;

            await appContext.SaveChangesAsync();

            return transportType;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transport = await appContext.TransportTypes.FindAsync(id);

            if (transport is null)
            {
                return false;
            }

            var deletedTransport = appContext.TransportTypes.Remove(transport).Entity;
            await appContext.SaveChangesAsync();

            return deletedTransport != null;
        }
    }
}
