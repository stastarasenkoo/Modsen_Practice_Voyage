using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Infrastructure.EntityConfigs
{
    internal class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {            
            builder.Property(t => t.FinalPrice)
                .HasPrecision(6, 2);
            builder.Property(t => t.Description)
                .HasMaxLength(500);
            builder.Property(b => b.TransportId)
                .IsRequired();
            builder.Property(b => b.RouteId)
                .IsRequired();
            builder.Property(b => b.DriverId)
                .IsRequired();
            builder.Property(b => b.DepartureTime)
                .IsRequired();
            builder.Property(b => b.ArrivalTime)
                .IsRequired();
            builder.Property(b => b.FreeSeats)
                .IsRequired();
            builder.Property(b => b.FinalPrice)
                .IsRequired();
        }
    }
}
