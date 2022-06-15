using Voyage.Business.Models;
using Voyage.DataAccess.Entities;

namespace Voyage.Business.Services.Interfaces
{
    public interface ITransportTypeService
    {
        Task<TransportType?> GetByIdAsync(int id);
        Task CreateAsync(TransportType transport);
        Task UpdateAsync(TransportType transport);
        Task DeleteAsync(int id);
    }
}
