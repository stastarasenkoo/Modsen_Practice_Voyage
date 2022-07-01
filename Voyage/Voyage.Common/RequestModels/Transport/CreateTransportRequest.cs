using Voyage.Common.Types;

namespace Voyage.Common.RequestModels.Transport
{
    public class CreateTransportRequest : ITransportInfo
    {
        public string Number { get; set; } = null!;

        public int SeatsCount { get; set; }

        public Color Color { get; set; }

        public string Mark { get; set; } = null!;

        public double PriceRate { get; set; }

        public TransportType Type { get; set; }
    }
}
