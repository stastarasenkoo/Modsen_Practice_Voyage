using Microsoft.AspNetCore.Identity;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DataAccess.Repositories
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AccountRepository(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<AppUser> RegisterAsync(AppUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Passenger");
                await signInManager.SignInAsync(user, false);
            }

            return user;
        }
    }
}
