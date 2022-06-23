using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voyage.Common.Entities;

namespace Voyage.DataAccess.Infrastructure.EntityConfigs
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.TripsCount).HasDefaultValue(0);
        }
    }
}
