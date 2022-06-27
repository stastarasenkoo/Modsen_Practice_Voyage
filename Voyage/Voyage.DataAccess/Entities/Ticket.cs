using Voyage.DataAccess.Entities.Types;

namespace Voyage.DataAccess.Entities
{
    public class Ticket
    {
        public int PassengerId { get; set; }

        public int TripId { get; set; }

        public DateTime PuchaseDate { get; set; }

        public TicketStatus Status { get; set; }

        public int BookedSeats { get; set; }

        public virtual Trip Trip { get; set; } = null!;

        public virtual Passenger Passenger { get; set; } = null!;
    }
}
