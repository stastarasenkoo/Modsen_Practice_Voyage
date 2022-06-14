using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess.Model
{
    internal class Driver
    {
        [Key]
        public int UserId { get; set; } //primary and foreign key
        public int DriverExperience { get; set; }
        public string DriverCategory { get; set; }
        public int TripCounts { get; set; }
        public Trip Trip { get; set; }
        public User User { get; set; }
    }
}
