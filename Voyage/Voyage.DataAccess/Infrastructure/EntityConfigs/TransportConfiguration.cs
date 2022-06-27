using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Infrastructure.EntityConfigs
{
    internal class TransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.HasIndex(t => t.Number)
                .IsUnique();
            builder.Property(t => t.Mark)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(t => t.Number)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(t => t.SeatsCount)
               .IsRequired();
            builder.Property(t => t.Color)
               .IsRequired();
            builder.Property(t => t.PriceRate)
               .IsRequired();
            builder.Property(t => t.Type)
              .IsRequired();
        }
    }
}
