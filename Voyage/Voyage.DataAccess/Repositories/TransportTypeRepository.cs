using Microsoft.EntityFrameworkCore;
using Voyage.DataAccess.Context;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DataAccess.Repositories
{
    public class TransportTypeRepository : ITransportTypeRepository
    {
        private readonly ApplicationDbContext appContext;

        public TransportTypeRepository(ApplicationDbContext context)
        {
            appContext = context;
        }

        public async Task<IEnumerable<TransportType>> GetAllAsync()
        {
           return await appContext.TransportTypes.ToListAsync();
        }

        public async Task<TransportType> GetByIdAsync(int id)
        {
            var transport = await appContext.TransportTypes.FindAsync(id);
            if (transport is null)
            {
               throw new ArgumentNullException(nameof(id));
            }
            return transport;
        }

        public async Task CreateAsync(TransportType transport)
        {
            await appContext.TransportTypes.AddAsync(transport);
            await appContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TransportType transport)
        {
            appContext.TransportTypes.Update(transport);
            await appContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transport = await appContext.TransportTypes.FindAsync(id);
            if (transport != null)
            {
                appContext.TransportTypes.Remove(transport);
                await appContext.SaveChangesAsync();
            }
        }
    }
}
