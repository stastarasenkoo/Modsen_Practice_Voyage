using Mapster;
using Microsoft.EntityFrameworkCore;
using Voyage.Common.Constants;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Entities;
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

        public async Task<TransportDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Transports
                .ProjectToType<TransportDetailsResponse>()
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<TransportShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken)
        {
            page = page <= 0 ? PaginationConstants.StartPage : page;

            return await context.Transports
                .OrderBy(r => r.Id)
                .Skip((page - PaginationConstants.PageStep) * PaginationConstants.PageSize)
                .Take(PaginationConstants.PageSize)
                .ProjectToType<TransportShortInfoResponse>()
                .ToListAsync(cancellationToken);
        }

        public async Task<TransportDetailsResponse> CreateAsync(CreateTransportRequest request, CancellationToken cancellationToken)
        {
            var transport = request.Adapt<Transport>();

            transport = context.Transports.Add(transport).Entity;

            await context.SaveChangesAsync(cancellationToken);

            return transport.Adapt<TransportDetailsResponse>();
        }

        public async Task<TransportDetailsResponse?> UpdateAsync(UpdateTransportRequest request, CancellationToken cancellationToken)
        {
            var transport = await context.Transports.AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

            if (transport is null)
            {
                return null;
            }

            TypeAdapterConfig<UpdateTransportRequest, Transport>
                .NewConfig()
                .Map(dest => dest.Mark, src => transport.Mark)
                .Map(dest => dest.SeatsCount, src => transport.SeatsCount);

            transport = request.Adapt<Transport>();
            context.Transports.Update(transport);

            await context.SaveChangesAsync(cancellationToken);

            return transport.Adapt<TransportDetailsResponse>();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var transport = await context.Transports.FindAsync(new object[] {id}, cancellationToken);

            if (transport is null)
            {
                return false;
            }

            var state = context.Transports.Remove(transport).State;

            await context.SaveChangesAsync(cancellationToken);

            return state == EntityState.Deleted;
        }
    }
}
