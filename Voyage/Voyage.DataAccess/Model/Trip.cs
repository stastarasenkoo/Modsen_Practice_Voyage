using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess.Model
{
    internal class Trip
    {
        [Key]
        public int TripId { get; set; } //primary key
        public int RouteId { get; set; } //foreign key
        public int DriverId { get; set; } //foreign key
        public int TransportTypeId { get; set; } //foreign key
        public string TransporNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal BaseCost { get; set; }
        public string Description { get; set; }
        

        public Ticket Ticket { get; set; }
        public Route Route { get; set; }
        public TransportType TransportType { get; set; }
        public Driver Driver { get; set; }
    }
}
