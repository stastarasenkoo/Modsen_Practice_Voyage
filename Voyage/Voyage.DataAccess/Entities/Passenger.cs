namespace Voyage.DataAccess.Entities
{
    public class Passenger
    {
        public int UserId { get; set; }

        public AppUser User { get; set; } = null!;

        public int Points { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = null!;
    }
}
