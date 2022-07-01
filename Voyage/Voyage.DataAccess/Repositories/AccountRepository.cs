using Mapster;
using Microsoft.AspNetCore.Identity;
using Voyage.Common.RequestModels.Account;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Infrastructure;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DataAccess.Repositories
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly ApplicationDbContext context;

        public AccountRepository(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<AppUser> RegisterAsync(SignUpRequestModel registerRequest, CancellationToken cancellationToken)
        {
            var user = registerRequest.Adapt<AppUser>();

            var result = await userManager.CreateAsync(user, registerRequest.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Passenger");

                await signInManager.SignInAsync(user, false);
            }

            await context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
