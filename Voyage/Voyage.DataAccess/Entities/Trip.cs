namespace Voyage.DataAccess.Entities
{
    public class Trip
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int DriverId { get; set; }

        public int TransportTypeId { get; set; }

        public string TransportNumber { get; set; } = null!;

        public DateTime DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public decimal BaseCost { get; set; }

        public string? Description { get; set; }

        public Route Route { get; set; } = null!;

        public TransportType TransportType { get; set; } = null!;

        public Driver Driver { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; } = null!;
    }
}
