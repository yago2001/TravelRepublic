using System;
using System.Collections.Generic;
using TravelRepublic.FlightCodingTest;
using TravelRepublic.OutputWriters;

namespace TravelRepublic
{
    class Program
    {
        static void Main(string[] args)
        {
            var flightBuilder = new FlightBuilder();
            IList<Flight> flights = flightBuilder.GetFlights();


            var outputWriter = new ConsoleOutputWriter(new ConsoleWrapper());
            outputWriter.Write(new FlightBuilder().GetFlights());
        }
    }
}
