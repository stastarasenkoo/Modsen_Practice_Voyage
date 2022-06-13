using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess
{
    internal class Passenger
    {
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
        public int TripsCount { get; set; }
        public int Points { get; set; }
    }
}
