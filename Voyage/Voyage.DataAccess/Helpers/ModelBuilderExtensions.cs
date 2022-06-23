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
                new IdentityRole<int> { Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole<int> { Name = "Driver", NormalizedName = "DRIVER" },
                new IdentityRole<int> { Name = "Passenger", NormalizedName = "PASSENGER" },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var users = new List<AppUser>() {
                new AppUser {
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
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Administrator").Id,
            });           
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);           
        }

    }
}
