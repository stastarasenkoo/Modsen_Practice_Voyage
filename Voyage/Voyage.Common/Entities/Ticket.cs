namespace Voyage.Common.Entities
{
    public class Ticket
    {
        public int PassengerId { get; set; }

        public int TripId { get; set; }

        public DateTime PuchaseDate { get; set; }

        public Trip Trip { get; set; } = null!;

        public Passenger Passenger { get; set; } = null!;
    }
}
