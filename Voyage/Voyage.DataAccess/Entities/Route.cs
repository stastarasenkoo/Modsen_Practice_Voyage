﻿namespace Voyage.DataAccess.Entities
{
    public class Route
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string DepartureAddress { get; set; } = null!;

        public string DestinationAddress { get; set; } = null!;

        public decimal BasePrice { get; set; }

        public int StopsCount { get; set; }

        public double Distance { get; set; }

        public virtual ICollection<Trip> Trips { get; set; } = null!;
    }
}
