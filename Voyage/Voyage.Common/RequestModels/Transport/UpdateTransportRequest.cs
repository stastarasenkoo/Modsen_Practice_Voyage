using Voyage.Common.Types;

namespace Voyage.Common.RequestModels.Transport
{
    public class UpdateTransportRequest : ITransportInfo
    {
        public int Id { get; set; }

        public string Number { get; set; } = null!;

        public Color Color { get; set; }

        public double PriceRate { get; set; }
    }
}
