using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage.Common.RequestModels.Route;

public interface IRouteInfo
{
    public string Name { get; set; }

    public string DepartureAddress { get; set; }

    public string DestinationAddress { get; set; }

    public decimal BasePrice { get; set; }

    public int StopsCount { get; set; }

    public double Distance { get; set; }
}
