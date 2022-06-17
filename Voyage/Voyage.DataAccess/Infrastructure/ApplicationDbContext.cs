using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Voyage.DataAccess.Entities;
using Voyage.DataAccess.Infrastructure.EntityConfigs;
using Voyage.DataAccess.Settings;

namespace Voyage.DataAccess.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public DbSet<Trip> Trips { get; set; } = null!;

        public DbSet<Route> Routes { get; set; } = null!;

        public DbSet<TransportType> TransportTypes { get; set; } = null!;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<DatabaseConfigs> databaseConfigs) : base(options)
        {
            Database.SetConnectionString(databaseConfigs.Value.ConnectionString);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
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
            builder.ApplyConfiguration(new TransportTypeConfiguration());
        }
    }
}
