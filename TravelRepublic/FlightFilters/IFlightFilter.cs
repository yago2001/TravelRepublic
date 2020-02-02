using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic.FlightFilters
{
    public interface IFlightFilter
    {
        bool ShouldBeFilterOut(Flight flight);
    }
}
