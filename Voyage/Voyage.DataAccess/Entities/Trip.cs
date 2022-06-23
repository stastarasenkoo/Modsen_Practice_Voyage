namespace Voyage.DataAccess.Entities
{
    public class Trip
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int DriverId { get; set; }

        public int TransportId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public decimal FinalPrice { get; set; }

        public string? Description { get; set; }

        public int FreeSeats { get; set; }

        public virtual Route Route { get; set; } = null!;

        public virtual Transport Transport { get; set; } = null!;

        public virtual Driver Driver { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; } = null!;
    }
}
