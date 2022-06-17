using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Voyage.DataAccess.Entities;

namespace Voyage.DataAccess.EntityKeys
{
    public class TicketKeyContainer
    {
        public int TripId { get; }

        public int PassengerId { get; }

        public TicketKeyContainer(int tripId, int passengerId)
        {
            TripId = tripId;
            PassengerId = passengerId;
        }
    }
}
