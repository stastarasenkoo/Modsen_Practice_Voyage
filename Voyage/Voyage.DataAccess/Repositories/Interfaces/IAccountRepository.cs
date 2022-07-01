using Voyage.Common.RequestModels.Account;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<AppUser> RegisterAsync(SignUpRequestModel registerRequest, CancellationToken cancellationToken);
    }
}
