using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<AppUser> RegisterAsync(AppUser user, string password);
    }
}
