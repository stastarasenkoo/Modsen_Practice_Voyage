namespace Voyage.Common.ResponseModels
{
    public class TicketDetailsResponse
    {
        public int TripId { get; set; }
        public int PassengerId { get; set; }
        public string PassengerName { get; set; } = null!;

        public decimal Price { get; set; }

        public TripShortInfoResponse TripShortInfo { get; set; } = null!;
    }
}
