using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.FlightCodingTest;
using TravelRepublic.FlightFilters;

namespace TravelRepublic.Tests.FlightFilters
{
    [TestFixture]
    class ArrivalDateBeforeDepartureDateFlightFilterTests
    {
        private DateTime _currentDate;
        private IFlightFilter _flightFilter;

        [SetUp]
        public void Setup()
        {
            this._currentDate = DateTime.Now;
            this._flightFilter = new ArrivalDateBeforeDepartureDateFlightFilter();
        }

        [Test]
        public void ShouldBeTrueForArrivalDateBeforeDepartureDate()
        {
            var flight = this.GetFlightWithArrivalDateBeforeDepartureDate();

            bool result = this._flightFilter.ShouldBeFilterOut(flight);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ShouldBeFalseForArrivalDateAfterDepartureDate()
        {
            var flight = this.GetFlightWithArrivalDateAfterDepartureDate();

            bool result = this._flightFilter.ShouldBeFilterOut(flight);

            Assert.That(result, Is.EqualTo(false));

        }

        private Flight GetFlightWithArrivalDateBeforeDepartureDate()
        {
            return new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(2),
                        ArrivalDate = this._currentDate.AddDays(1)
                    }
                }
            };
        }

        private Flight GetFlightWithArrivalDateAfterDepartureDate()
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

