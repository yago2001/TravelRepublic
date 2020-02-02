using System;
using System.Collections.Generic;
using TravelRepublic.FlightCodingTest;
using TravelRepublic.FlightFilters;
using TravelRepublic.OutputWriters;

namespace TravelRepublic
{
    class Program
    {
        static void Main(string[] args)
        {
            var flightBuilder = new FlightBuilder();
            IList<Flight> flights = flightBuilder.GetFlights();
            var flightSelector = GetFlightSelector();

            var filteredFlights = flightSelector.Select(flights);

            var outputWriter = new ConsoleOutputWriter(new ConsoleWrapper());
            outputWriter.Write(filteredFlights);
        }


        private static FlightSelector GetFlightSelector()
        {
            return new FlightSelector(new List<IFlightFilter>
            {
                new DepartureBeforeCurrentDateFlightFilter(),
                new ArrivalDateBeforeDepartureDateFlightFilter(),
                new SpendMoreThan2HoursOnTheGroundFlightFilter()
            });
        }
    }
}
