using Voyage.DataAccess.Entities.Enums;

namespace Voyage.DataAccess.Entities
{
    public class Transport
    {
        public int Id { get; set; }

        public string Number { get; set; } = null!;

        public int SeatsCount { get; set; }

        public Color Color { get; set; }

        public string Mark { get; set; } = null!;

        public double PriceRate { get; set; }

        public TransportType Type { get; set; }

        public ICollection<Trip> Trips { get; set; } = null!;
    }
}
