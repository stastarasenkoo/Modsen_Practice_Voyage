using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess.Model
{
    internal class Route
    {
        [Key]
        public int RouteId { get; set; } //primary key
        public string RouteName { get; set; }
        public string DepartureAdress { get; set; }
        public string DestinationAdress { get; set; }
        public int StopsCount { get; set; }
        public double Distance { get; set; }

        public Trip Trip { get; set; }
    }
}
