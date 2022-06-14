using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage.DataAccess.Model;

namespace Voyage.DataAccess.Context
{
    internal class ApplicationDbContext:DbContext
    {
        DbSet<Driver> Drivers { get; set; }
        DbSet<Passenger> Passengers { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Route> Routes { get; set; }
        DbSet<Ticket> Tickets { get; set; }
        DbSet<TransportType> TransportTypes { get; set; }
        DbSet<Trip> Trips { get; set; }
        DbSet<User> Users { get; set; }

        public ApplicationDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VoyageDataBase;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(p => p.Role)
            .WithMany(t => t.Users)
            .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<Passenger>()
            .HasOne(p => p.User)
            .WithOne(t => t.Passenger)
            .HasForeignKey<User>(p => p.UserId);

            modelBuilder.Entity<Ticket>()
            .HasOne(p => p.Passenger)
            .WithMany(t => t.Tickets)
            .HasForeignKey(p => p.PassengerId);

            modelBuilder.Entity<Ticket>()
            .HasOne(p => p.Trip)
            .WithOne(t => t.Ticket)
            .HasForeignKey<Trip>(p => p.TripId);

            modelBuilder.Entity<Trip>()
            .HasOne(p => p.Route)
            .WithOne(t => t.Trip)
            .HasForeignKey<Route>(p => p.RouteId);

            modelBuilder.Entity<Trip>()
            .HasOne(p => p.TransportType)
            .WithOne(t => t.Trip)
            .HasForeignKey<TransportType>(p => p.TransportTypeId);

            modelBuilder.Entity<Trip>()
            .HasOne(p => p.Driver)
            .WithOne(t => t.Trip)
            .HasForeignKey<Driver>(p => p.UserId);

            modelBuilder.Entity<Driver>()
            .HasOne(p => p.User)
            .WithOne(t => t.Driver)
            .HasForeignKey<User>(p => p.UserId);
        }

    }
}
