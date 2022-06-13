using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess
{
    internal class Ticket
    {
        public int PassengerId { get; set; }//внешний ключ
        public Passenger Passenger { get; set; }//навигационное свойство

        /*
        public int TripId { get; set; }//внешний ключ
        public Trip Trip { get; set; }//навигационное свойство
        */

        //эти ключи так же первичные.Донастрою при настройке контекста

        public DateTime PuchaseDate { get; set; }
        public decimal Cost { get; set; }

    }
}
