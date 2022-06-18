using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Infrastructure.EntityConfigs
{
    internal class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.Property(t => t.BaseCost).HasPrecision(5, 2);
            builder.Property(t => t.TransportNumber).HasMaxLength(20);
            builder.Property(t => t.Description).HasMaxLength(500);
        }
    }
}
