using Voyage.Common.RequestModels;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<AppUser> RegisterAsync(RegisterModelRequest registerRequest, CancellationToken cancellationToken);
    }
}
