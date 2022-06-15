namespace Voyage.DataAccess.Models
{
    public class Ticket
    {
        public int PassengerId { get; set; }

        public Passenger Passenger { get; set; } = null!;

        public int TripId { get; set; }

        public Trip Trip { get; set; } = null!;

        public DateTime PuchaseDate { get; set; }

        public decimal Cost { get; set; }
    }
}
