using Voyage.Common.Types;

namespace Voyage.Common.RequestModels.Transport;

public interface ITransportInfo
{
    public string Number { get; set; }

    public Color Color { get; set; }

    public double PriceRate { get; set; }
}
