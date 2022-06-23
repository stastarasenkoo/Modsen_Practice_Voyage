using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Helpers
{
    internal static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roles = new List<IdentityRole<int>>() {
                new IdentityRole<int> {Id=1, Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole<int> {Id=2, Name = "Driver", NormalizedName = "DRIVER" },
                new IdentityRole<int> {Id=3, Name = "Passenger", NormalizedName = "PASSENGER" },
            };
            modelBuilder.Entity<IdentityRole<int>>().HasData(roles);

            var users = new List<AppUser>() {
                new AppUser {
                    Id = 1,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "HeadAdmin",
                    NormalizedUserName = "HEADADMIN",
                }
            };
            modelBuilder.Entity<AppUser>().HasData(users);

            var passwordHasher = new PasswordHasher<AppUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "qwert123Q_1");

            var userRoles = new List<IdentityUserRole<int>>();
            userRoles.Add(new IdentityUserRole<int>
            {
                UserId = 1,
                RoleId = roles.First(q => q.Name == "Administrator").Id,
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);
        }

    }
}
