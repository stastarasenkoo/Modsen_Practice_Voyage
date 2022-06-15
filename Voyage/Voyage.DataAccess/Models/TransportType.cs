namespace Voyage.DataAccess.Models
{
    public class TransportType
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double CostRate { get; set; }

        public ICollection<Trip> Trips { get; set; } = null!;
    }
}
