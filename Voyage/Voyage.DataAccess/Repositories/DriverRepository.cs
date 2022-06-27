using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Voyage.Common.Constants;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Infrastructure;
using Voyage.DataAccess.Repositories.Interfaces;

namespace Voyage.DataAccess.Repositories
{
    internal class DriverRepository : IDriverRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ApplicationDbContext context;

        public DriverRepository(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<DriverDetailsResponse?> FindAsync(int id, CancellationToken cancellationToken)
        {
            return await context.Drivers
                .ProjectToType<DriverDetailsResponse>()
                .FirstOrDefaultAsync(r => r.UserId == id, cancellationToken);
        }

        public async Task<IEnumerable<DriverDetailsResponse>> FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await context.Drivers
                .Where(r => r.User.FirstName.Contains(name))
                .OrderBy(r => r.User.FirstName)
                .ProjectToType<DriverDetailsResponse>()
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<DriverShortInfoResponse>> GetAsync(int page, CancellationToken cancellationToken)
        {
            page = page <= 0 ? PaginationConstants.StartPage : page;

            return await context.Drivers
                .OrderBy(r => r.UserId)
                .Skip((page - PaginationConstants.PageStep) * PaginationConstants.PageSize)
                .Take(PaginationConstants.PageSize)
                .ProjectToType<DriverShortInfoResponse>()
                .ToListAsync(cancellationToken);
        }

        public async Task<DriverDetailsResponse> CreateAsync(CreateDriverRequest request, CancellationToken cancellationToken)
        {
            var user = request.Adapt<AppUser>();

            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Driver");

                await signInManager.SignInAsync(user, false);
            }
            else
            {
                return request.Adapt<DriverDetailsResponse>();
            }

            await context.SaveChangesAsync(cancellationToken);

            var driver = request.Adapt<Driver>();

            driver.UserId = user.Id;

            context.Drivers.Add(driver);

            await context.SaveChangesAsync(cancellationToken);

            return driver.Adapt<DriverDetailsResponse>();
        }

        public async Task<DriverDetailsResponse?> UpdateAsync(UpdateDriverRequest request, CancellationToken cancellationToken)
        {
            var driver = context.Drivers.AsNoTracking().FirstOrDefault(u => u.UserId == request.UserId);

            if (driver is null)
            {
                return request.Adapt<DriverDetailsResponse>();
            }

            driver.DriverCategory = (Entities.Enums.DriverCategoryType)request.DriverCategory;
            driver.DrivingExperience = request.DrivingExperience;

            var user = context.Users.AsNoTracking().FirstOrDefault(u => u.Id == request.UserId);

            if (user is null)
            {
                return request.Adapt<DriverDetailsResponse>();
            }

            user.FirstName = request.FirstName;
            user.SecondName = request.SecondName;
            user.ThirdName = request.ThirdName;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;

            context.Drivers.Update(driver);

            context.Users.Update(user);

            await context.SaveChangesAsync(cancellationToken);

            return driver.Adapt<DriverDetailsResponse>();
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var driver = context.Drivers.FirstOrDefault(u => u.UserId == id);

            if (driver is null)
            {
                return false;
            }

            var state = context.Drivers.Remove(driver).State;

            await context.SaveChangesAsync(cancellationToken);

            var user = context.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
            {
                return false;
            }

            await userManager.RemoveFromRoleAsync(user, "Driver");

            await userManager.DeleteAsync(user);

            await context.SaveChangesAsync(cancellationToken);

            return state == EntityState.Deleted;
        }
    }
}
