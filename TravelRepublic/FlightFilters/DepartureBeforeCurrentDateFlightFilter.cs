using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic.FlightFilters
{
    public class DepartureBeforeCurrentDateFlightFilter : IFlightFilter
    {
        public bool ShouldBeFilterOut(Flight flight)
        {
            DateTime currentDate = DateTime.Now;

            return flight.Segments.Any(segment => segment.DepartureDate < currentDate);
        }
    }
}
