namespace Voyage.Business.Models
{
    public class TransportTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double CostRate { get; set; }
    }
}
