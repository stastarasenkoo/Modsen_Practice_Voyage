using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.Infrastructure.EntityConfigs
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new { t.TripId, t.PassengerId });
            builder.HasOne(t => t.Passenger).WithMany(p => p.Tickets)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
