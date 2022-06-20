using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.Common.RequestModels
{
    public class GetTicketsRequest
    {
        public int? TripId { get; set; }

        public int? PassengerId { get; set; }
    }
}
