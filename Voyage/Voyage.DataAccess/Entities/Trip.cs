namespace Voyage.DataAccess.Entities
{
    public class Trip
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; } = null!;

        public int DriverId { get; set; }

        public Driver Driver { get; set; } = null!;

        public int TransportTypeId { get; set; }

        public TransportType TransportType { get; set; } = null!;

        public string TransportNumber { get; set; } = null!;

        public DateTime DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public decimal BaseCost { get; set; }

        public string? Description { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = null!;
    }
}
