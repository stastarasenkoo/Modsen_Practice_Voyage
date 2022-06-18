namespace Voyage.DataAccess.EntityKeys
{
    public class TicketKey
    {
        public int TripId { get; }

        public int PassengerId { get; }

        public TicketKey(int tripId, int passengerId)
        {
            TripId = tripId;
            PassengerId = passengerId;
        }
    }
}
