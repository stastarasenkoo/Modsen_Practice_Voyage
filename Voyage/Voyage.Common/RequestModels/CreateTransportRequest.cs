using Voyage.Common.Enums;

namespace Voyage.Common.RequestModels
{
    public class CreateTransportRequest
    {
        public string Number { get; set; } = null!;

        public int SeatsCount { get; set; }

        public Color Color { get; set; }

        public string Mark { get; set; } = null!;

        public double PriceRate { get; set; }
    }
}
