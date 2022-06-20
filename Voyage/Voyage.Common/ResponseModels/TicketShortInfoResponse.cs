namespace Voyage.Common.ResponseModels
{
    public class TicketShortInfoResponse
    {
        public int? TripId { get; set; }

        public int? PassengerId { get; set; }
        public string RouteName { get; set; } = null!;

        public DateTime TripDate { get; set; }

        public decimal Price { get; set; }
    }
}
