namespace Voyage.Common.RequestModels.Route
{
    public class CreateRouteRequest : IRouteInfo
    {
        public string Name { get; set; } = null!;

        public string DepartureAddress { get; set; } = null!;

        public string DestinationAddress { get; set; } = null!;

        public decimal BasePrice { get; set; }

        public int StopsCount { get; set; }

        public double Distance { get; set; }
    }
}
