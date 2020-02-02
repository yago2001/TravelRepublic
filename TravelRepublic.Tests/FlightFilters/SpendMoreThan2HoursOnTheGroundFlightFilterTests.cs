using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.FlightCodingTest;
using TravelRepublic.FlightFilters;

namespace TravelRepublic.Tests.FlightFilters
{
    [TestFixture]
    class SpendMoreThan2HoursOnTheGroundFlightFilterTests
    {
        private DateTime _currentDate;
        private IFlightFilter _flightFilter;

        [SetUp]
        public void Setup()
        {
            this._currentDate = DateTime.Now;
            this._flightFilter = new SpendMoreThan2HoursOnTheGroundFlightFilter();
        }

        [Test]
        public void ShouldBeTrueForDepatureBeforeCurrentDate()
        {
            var flight = this.GetFlightWithMoreThan2HoursOnTheGround();

            bool result = this._flightFilter.ShouldBeFilterOut(flight);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void ShouldBeFalseForDepartureAfterCurrentDate()
        {
            var flight = this.GetFlightWithLessThan2HoursOnTheGround();

            bool result = this._flightFilter.ShouldBeFilterOut(flight);

            Assert.That(result, Is.EqualTo(false));

        }

        private Flight GetFlightWithMoreThan2HoursOnTheGround()
        {
            return new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(-1),
                        ArrivalDate = this._currentDate.AddDays(1)
                    },
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(2),
                        ArrivalDate = this._currentDate.AddDays(3)
                    }
                }
            };
        }

        private Flight GetFlightWithLessThan2HoursOnTheGround()
        {
            return new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(1),
                        ArrivalDate = this._currentDate.AddDays(2),
                    },
                    new Segment
                    {
                        DepartureDate = this._currentDate.AddDays(2).AddHours(1),
                        ArrivalDate = this._currentDate.AddDays(3),
                    }
                }
            };
        }

    }
}
