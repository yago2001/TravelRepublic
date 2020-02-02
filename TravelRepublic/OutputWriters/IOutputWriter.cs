using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic.OutputWriters
{
    public interface IOutputWriter
    {
        public void Write(IList<Flight> flights);
    }
}
