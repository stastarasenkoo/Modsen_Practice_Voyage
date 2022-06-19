namespace Voyage.Common.ResponseModels
{
    public class TicketDetailsResponse
    {
        public string PassengerName { get; set; } = null!;

        public decimal Price { get; set; }

        public TripShortInfoResponse TripShortInfo { get; set; } = null!;
    }
}
