namespace Voyage.Common.RequestModels
{
    public class UpdateTripRequest
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int DriverId { get; set; }

        public int TransportId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal FinalPrice { get; set; }

        public string? Description { get; set; }

        public int FreeSeats { get; set; }
    }
}
