namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task<TEntity?> FindAsync(TKey key);

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TKey key);
    }
}
