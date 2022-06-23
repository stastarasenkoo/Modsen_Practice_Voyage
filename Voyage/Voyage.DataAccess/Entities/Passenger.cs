namespace Voyage.DataAccess.Entities
{
    public class Passenger
    {
        public int UserId { get; set; }

        public int Points { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = null!;

        public virtual AppUser User { get; set; } = null!;
    }
}
