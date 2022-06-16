namespace Voyage.WebAPI.Models
{
    public class CreateTransportTypeRequest
    {
        public string Name { get; set; } = null!;

        public double CostRate { get; set; }
    }
}
