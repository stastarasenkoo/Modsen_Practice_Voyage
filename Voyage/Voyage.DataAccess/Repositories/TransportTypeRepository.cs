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
        public async Task<TransportType?> GetByIdAsync(int id)
        {
            return await appContext.TransportTypes.FindAsync(id);
        }

        public async Task CreateAsync(TransportType transport)
        {
            appContext.TransportTypes.Add(transport);
            await appContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TransportType transport)
        {
            appContext.TransportTypes.Update(transport);
            await appContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transport = appContext.TransportTypes.Find(id);
            if (transport != null)
            {
                appContext.TransportTypes.Remove(transport);
                await appContext.SaveChangesAsync();
            }
        }
    }
}
