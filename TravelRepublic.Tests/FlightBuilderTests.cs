using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic.Tests
{
    [TestFixture]
    public class FlightBuilderTests
    {
        private readonly int _totalNumberOfExpectedFlights = 6;
        private FlightBuilder _flightBuiider = new FlightBuilder();

        [Test]
        public void ShouldReturn6Flights()
        {
            IList<Flight> flights = this._flightBuiider.GetFlights();            

            Assert.That(flights.Count, Is.EqualTo(this._totalNumberOfExpectedFlights));
        }
    }
}