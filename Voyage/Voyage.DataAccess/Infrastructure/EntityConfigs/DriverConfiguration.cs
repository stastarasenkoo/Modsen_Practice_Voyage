using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Infrastructure.EntityConfigs
{
    internal class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(d => d.UserId);
            builder.Property(b => b.DrivingExperience)
                .IsRequired();
            builder.Property(b => b.DriverCategory)
                .IsRequired();
        }
    }
}
