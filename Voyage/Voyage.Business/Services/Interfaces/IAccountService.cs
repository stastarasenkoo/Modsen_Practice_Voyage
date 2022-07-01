using Voyage.Common.RequestModels.Account;
using Voyage.DataAccess.Entities;

namespace Voyage.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AppUser> RegisterAsync(SignUpRequestModel registerRequest, CancellationToken cancellationToken);
    }
}
