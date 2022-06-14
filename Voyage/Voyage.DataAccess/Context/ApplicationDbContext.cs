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

    }
}
