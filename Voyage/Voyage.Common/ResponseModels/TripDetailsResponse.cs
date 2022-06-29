using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.Common.ResponseModels
{
    public class TripDetailsResponse
    {
        public int Id { get; set; }

        public string RouteName { get; set; } = null!;

        public DateTime DepartureTime { get; set; }

        public string DriverName { get; set; } = null!;

        public string TransportNumber { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal? FinalPrice { get; set; }

        public string? Description { get; set; }

        public int? FreeSeats { get; set; }
    }
}
