using Voyage.Business.Models;
using Voyage.DataAccess.Entities;

namespace Voyage.Business.Services.Interfaces
{
    public interface ITransportTypeService
    {
        Task<IEnumerable<TransportTypeDto>> GetAllAsync();
        Task<TransportTypeDto> GetByIdAsync(int id);
        Task CreateAsync(TransportTypeDto transport);
        Task UpdateAsync(TransportTypeDto transport);
        Task DeleteAsync(int id);
    }
}
