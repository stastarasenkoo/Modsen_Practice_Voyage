﻿using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface ITransportTypeRepository
    {
        Task<IEnumerable<TransportType>> GetAllAsync();        
        Task<TransportType> GetByIdAsync(int id);
        Task CreateAsync(TransportType transport);
        Task UpdateAsync(TransportType transport);
        Task DeleteAsync(int id);
    }
}
