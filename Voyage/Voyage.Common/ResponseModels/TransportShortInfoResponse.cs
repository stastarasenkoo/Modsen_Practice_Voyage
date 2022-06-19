namespace Voyage.Common.ResponseModels
{
    public class TransportShortInfoResponse
    {
        public int Id { get; set; }

        public string Number { get; set; } = null!;

        public int SeatsCount { get; set; }

        public string Mark { get; set; } = null!;
    }
}
