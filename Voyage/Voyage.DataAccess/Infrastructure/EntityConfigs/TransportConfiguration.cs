using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Infrastructure.EntityConfigs
{
    internal class TransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.HasIndex(t => t.Number).IsUnique();
            builder.Property(t => t.Mark).HasMaxLength(30);
            builder.Property(t => t.Number).HasMaxLength(20);
        }
    }
}
