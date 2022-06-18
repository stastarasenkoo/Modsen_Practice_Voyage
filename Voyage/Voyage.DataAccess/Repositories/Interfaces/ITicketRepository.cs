using Voyage.Common.Dtos;
using Voyage.DataAccess.EntityKeys;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface ITicketRepository : IRepository<TicketDto, TicketKey>
    {
    }
}
