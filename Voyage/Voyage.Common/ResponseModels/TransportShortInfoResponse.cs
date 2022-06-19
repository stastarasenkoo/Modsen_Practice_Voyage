using Voyage.Common.Enums;

namespace Voyage.Common.ResponseModels
{
    public class TransportShortInfoResponse
    {
        public int Id { get; set; }

        public int SeatsCount { get; set; }

        public string Mark { get; set; } = null!;

        public TransportType Type { get; set; }
    }
}
