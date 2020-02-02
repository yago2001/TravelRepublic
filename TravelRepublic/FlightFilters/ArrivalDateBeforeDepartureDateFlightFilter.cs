using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic.FlightFilters
{
    public class ArrivalDateBeforeDepartureDateFlightFilter : IFlightFilter
    {
        public bool ShouldBeFilterOut(Flight flight)
        {
            return flight.Segments.Any(segment => segment.ArrivalDate < segment.DepartureDate);
        }
    }
}
