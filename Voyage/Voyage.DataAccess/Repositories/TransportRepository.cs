using Mapster;
using Microsoft.EntityFrameworkCore;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Entities.Enums;
using Voyage.DataAccess.Infrastructure;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DataAccess.Repositories
{
    internal class TransportRepository : ITransportRepository
    {
        private readonly ApplicationDbContext context;

        public TransportRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<TransportDetailsResponse> CreateAsync(CreateTransportRequest request)
        {
            var transport = request.Adapt<Transport>();

            transport = context.Transports.Add(transport).Entity;

            await context.SaveChangesAsync();

            return transport.Adapt<TransportDetailsResponse>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transport = await context.Transports.FindAsync(id);

            if (transport is null)
            {
                return false;
            }

            var state = context.Transports.Remove(transport).State;

            await context.SaveChangesAsync();

            return state == EntityState.Deleted;
        }

        public async Task<TransportDetailsResponse?> FindAsync(int id)
        {
            var transport = await context.Transports.FindAsync(id);
            
            return transport?.Adapt<TransportDetailsResponse>();
        }

        public async Task<IEnumerable<TransportShortInfoResponse>> GetAsync()
        {
            return await Task.Run(() =>
            {
                return context.Transports.ProjectToType<TransportShortInfoResponse>();
            });
        }

        public async Task<TransportDetailsResponse?> UpdateAsync(UpdateTransportRequest request)
        {
            var transport = await context.Transports.FindAsync(request.Id);

            if (transport is null)
            {
                return null;
            }

            transport.Number = request.Number;
            transport.Color = (Color)request.Color;
            transport.PriceRate = request.PriceRate;

            await context.SaveChangesAsync();

            return transport.Adapt<TransportDetailsResponse>();
        }
    }
}
