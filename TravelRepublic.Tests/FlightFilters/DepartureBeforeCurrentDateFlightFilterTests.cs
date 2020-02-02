using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.FlightCodingTest;
using TravelRepublic.FlightFilters;

namespace TravelRepublic.Tests.FlightFilters
{    
    [TestFixture]
    class DepartureBeforeCurrentDateFlightFilterTests
    {
        private DateTime _currentDate;
        private IFlightFilter _flightFilter;

        [SetUp]
        public void Setup()
        {
            this._currentDate = DateTime.Now;
            this._flightFilter = new DepartureBeforeCurrentDateFlightFilter();
        }

        [Test]
        public void ShouldBeTrueForDepatureBeforeCurrentDate()
        {
            var flight = this.GetFlightWithDepartureBeforeCurrentDate();

            bool result = this._flightFilter.ShouldBeFilterOut(flight);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ShouldBeFalseForDepartureAfterCurrentDate()
        {
            var flight = this.GetFlightWithDepartureDateAfterCurrentDate();

            bool result = this._flightFilter.ShouldBeFilterOut(flight);

            Assert.That(result, Is.EqualTo(false));

        }

        private Flight GetFlightWithDepartureBeforeCurrentDate()
        {
            return new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(-1),
                        ArrivalDate = this._currentDate.AddDays(1)
                    }
                }
            };
        }

        private Flight GetFlightWithDepartureDateAfterCurrentDate()
        {
            return new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(1),
                        ArrivalDate = this._currentDate.AddDays(2),
                    }
                }
            };
        }
    }
}
