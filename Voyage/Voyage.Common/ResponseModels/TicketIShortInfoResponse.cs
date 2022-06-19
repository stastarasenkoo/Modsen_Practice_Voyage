namespace Voyage.Common.ResponseModels
{
    public class TicketIShortInfoResponse
    {
        public string RouteName { get; set; } = null!;

        public DateTime TripDate { get; set; }

        public decimal Price { get; set; }
    }
}
