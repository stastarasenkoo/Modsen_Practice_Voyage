namespace Voyage.Common.ResponseModels
{
    public class TicketShortInfoResponse
    {
        public string RouteName { get; set; } = null!;

        public DateTime TripDate { get; set; }

        public decimal Price { get; set; }
    }
}
