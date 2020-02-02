using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.FlightCodingTest;
using TravelRepublic.FlightFilters;
using System.Linq;

namespace TravelRepublic
{
    public class FlightSelector
    {
        private readonly IList<IFlightFilter> _flightFilters;

        public FlightSelector(IList<IFlightFilter> flightFilters)
        {
            this._flightFilters = flightFilters;
        }

        public IList<Flight> Select(IList<Flight> flights)
        {
            var filteredFlights = flights.ToList();

            filteredFlights
                .RemoveAll(flight => this._flightFilters.Any(filter => filter.ShouldBeFilterOut(flight)));

            return filteredFlights;
        }

    }
}
