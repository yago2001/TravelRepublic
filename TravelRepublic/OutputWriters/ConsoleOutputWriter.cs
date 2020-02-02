using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic.OutputWriters
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        private readonly IConsoleWrapper _console;
        private readonly string _dateFormat = "yyyy-MMM-dd HH:mm:ss";

        public ConsoleOutputWriter(IConsoleWrapper console)
        {
            this._console = console;
        }

        public void Write(IList<Flight> flights)
        {
            //throw new NotImplementedException();

            int flightCount = 1;

            foreach (var flight in flights)
            {
                int segmentCount = 1;
                this._console.WriteLine($"Flight-{flightCount:00}");
                this._console.WriteLine("---------");
                this._console.WriteLine();
                foreach (var segment in flight.Segments)
                {
                    this._console.Write($"Segment-{segmentCount:00}: ");
                    this._console.Write(segment.DepartureDate.ToString(this._dateFormat));
                    this._console.WriteLine(" - "  + segment.ArrivalDate.ToString(this._dateFormat));

                    segmentCount++;
                }
                this._console.WriteLine();
                this._console.WriteLine();
                flightCount++;
            }
        }
    }
}
