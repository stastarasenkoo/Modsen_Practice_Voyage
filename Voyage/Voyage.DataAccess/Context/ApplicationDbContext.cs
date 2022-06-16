using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public DbSet<Trip> Trips { get; set; } = null!;

        public DbSet<Route> Routes { get; set; } = null!;

        public DbSet<TransportType> TransportTypes { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AddCoreModelsConstraints(builder);
            base.OnModelCreating(builder);
        }

        private static void AddCoreModelsConstraints(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<AppUser>()
                .Property(u => u.TripsCount)
                .HasDefaultValue(0);

            // Driver
            modelBuilder.Entity<Driver>()
                .HasKey(d => d.UserId);

            // Passenger
            modelBuilder.Entity<Passenger>()
                .HasKey(p => p.UserId);

            // Ticket
            modelBuilder.Entity<Ticket>()
                .HasKey(t => new { t.TripId, t.PassengerId });

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Cost)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Passenger)
                .WithMany(p => p.Tickets)
                .OnDelete(DeleteBehavior.Restrict);

            // Trip
            modelBuilder.Entity<Trip>()
                .Property(t => t.BaseCost)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Trip>()
                .Property(t => t.TransportNumber)
                .HasMaxLength(20);

            modelBuilder.Entity<Trip>()
                .Property(t => t.Description)
                .HasMaxLength(500);

            // Route
            modelBuilder.Entity<Route>()
                .Property(r => r.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<Route>()
                .Property(r => r.DepartureAddress)
                .HasMaxLength(200);

            modelBuilder.Entity<Route>()
                .Property(r => r.DestinationAddress)
                .HasMaxLength(200);

            // TransportType
            modelBuilder.Entity<TransportType>()
                .Property(tt => tt.Name)
                .HasMaxLength(100);
        }
    }
}
