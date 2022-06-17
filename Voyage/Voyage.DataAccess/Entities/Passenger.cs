namespace Voyage.DataAccess.Entities
{
    public class Passenger
    {
        public int UserId { get; set; }

        public int Points { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = null!;

        public AppUser User { get; set; } = null!;
    }
}
