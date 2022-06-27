namespace Voyage.Common.RequestModels
{
    public class GetTicketsRequest
    {
        public int? TripId { get; set; }

        public int? PassengerId { get; set; }
    }
}
