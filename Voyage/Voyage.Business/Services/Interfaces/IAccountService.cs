using Voyage.Common.RequestModels;
using Voyage.DataAccess.Entities;

namespace Voyage.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AppUser> RegisterAsync(RegisterModelRequest registerRequest, CancellationToken cancellationToken);
    }
}
