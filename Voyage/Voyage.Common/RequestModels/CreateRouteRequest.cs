namespace Voyage.Common.RequestModels
{
    public class CreateRouteRequest
    {
        public string Name { get; set; } = null!;

        public string DepartureAddress { get; set; } = null!;

        public string? DestinationAddress { get; set; }

        public decimal BasePrice { get; set; }

        public int StopsCount { get; set; }

        public double Distance { get; set; }
    }
}
