using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess.Model
{
    internal class Passenger
    {
        [Key]
        public int UserId { get; set; } //foreign and primary key
        public User User { get; set; } //navigational property
        public int TripsCount { get; set; }
        public int Points { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
