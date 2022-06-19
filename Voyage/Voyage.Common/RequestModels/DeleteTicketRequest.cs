namespace Voyage.Common.RequestModels
{
    public class DeleteTicketRequest
    {
        public int TripId { get; set; }

        public int PassengerId { get; set; }
    }
}
