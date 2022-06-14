using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess.Model
{
    internal class TransportType
    {
        public int TransportTypeId { get; set; } //primary key
        public string Name { get; set; }
        public double CostRate { get; set; }
    }
}
