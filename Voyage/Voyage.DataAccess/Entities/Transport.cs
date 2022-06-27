using Voyage.DataAccess.Entities.Types;

namespace Voyage.DataAccess.Entities
{
    public class Transport
    {
        public int Id { get; set; }

        public string Number { get; set; } = null!;

        public int SeatsCount { get; set; }

        public ColorType Color { get; set; }

        public string Mark { get; set; } = null!;

        public double PriceRate { get; set; }

        public TransportType Type { get; set; }

        public virtual ICollection<Trip> Trips { get; set; } = null!;
    }
}
