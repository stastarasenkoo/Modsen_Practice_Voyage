using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.DataAccess.Model
{
    internal class TransportType
    {
        [Key]
        public int TransportTypeId { get; set; } //primary key
        public string Name { get; set; }
        public double CostRate { get; set; }

        public Trip Trip { get; set; }
    }
}
