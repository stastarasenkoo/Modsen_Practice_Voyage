using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels.Account;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Repositories.Interfaces;


namespace Voyage.Business.Services
{
    internal class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AppUser> RegisterAsync(SignUpRequestModel registerRequest, CancellationToken cancellationToken)
        {
            return await repository.RegisterAsync(registerRequest, cancellationToken);
        }
    }
}
