using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess.Model
{
    internal class Ticket
    {
        public int PassengerId { get; set; }//foreign key
        public Passenger Passenger { get; set; }//navigational property
        public int TripId { get; set; }//foreign key
        public Trip Trip { get; set; }//navigational property
        //This keys also primary.Fix later when create context
        public DateTime PuchaseDate { get; set; }
        public decimal Cost { get; set; }

    }
}
