using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Voyage.Common.Settings;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Helpers;
using Voyage.DataAccess.Infrastructure.EntityConfigs;

namespace Voyage.DataAccess.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public DbSet<Trip> Trips { get; set; } = null!;

        public DbSet<Route> Routes { get; set; } = null!;

        public DbSet<Transport> Transports { get; set; } = null!;

        public DbSet<Ticket> Tickets { get; set; } = null!;

        public DbSet<Driver> Drivers { get; set; } = null!;

        public DbSet<Passenger> Passengers { get; set; } = null!;



        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<DatabaseConfigs> databaseConfigs
           ) : base(options)
        {
            Database.SetConnectionString(databaseConfigs.Value.ConnectionString);
            //SeedData.EnsureSeedData(databaseConfigs.Value.ConnectionString);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {          
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            ConfigureEntities(builder);
            base.OnModelCreating(builder);
        }

        private static void ConfigureEntities(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new DriverConfiguration());
            builder.ApplyConfiguration(new PassengerConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new TripConfiguration());
            builder.ApplyConfiguration(new RouteConfiguration());
            builder.ApplyConfiguration(new TransportConfiguration());
        }
    }
}
