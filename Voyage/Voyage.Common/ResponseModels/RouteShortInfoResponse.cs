namespace Voyage.Common.ResponseModels
{
    public class RouteShortInfoResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal BasePrice { get; set; }
    }
}
