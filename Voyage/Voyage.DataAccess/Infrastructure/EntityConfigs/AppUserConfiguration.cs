using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Infrastructure.EntityConfigs
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.TripsCount)
                .HasDefaultValue(0);
            builder.Property(b => b.FirstName)
                .IsRequired();
            builder.Property(b => b.SecondName)
                .IsRequired();
        }
    }
}
