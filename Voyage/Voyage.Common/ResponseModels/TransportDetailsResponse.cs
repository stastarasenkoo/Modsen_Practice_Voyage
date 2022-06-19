using Voyage.Common.Enums;

namespace Voyage.Common.ResponseModels
{
    public class TransportDetailsResponse
    {
        public int Id { get; set; }

        public string Number { get; set; } = null!;

        public int SeatsCount { get; set; }

        public Color Color { get; set; }

        public string Mark { get; set; } = null!;

        public double PriceRate { get; set; }

        public TransportType Type { get; set; }
    }
}
