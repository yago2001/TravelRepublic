using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.FlightCodingTest;
using TravelRepublic.FlightFilters;

namespace TravelRepublic.Tests
{
    [TestFixture]
    class FlightSelectorTests
    {
        private Mock<IFlightFilter> _firstFilter;
        private Mock<IFlightFilter> _secondFilter;

        private FlightSelector _flightSelector;

        [SetUp]
        public void Setup()
        {
            this._firstFilter = new Mock<IFlightFilter>();
            this._secondFilter = new Mock<IFlightFilter>();

             this._flightSelector = new FlightSelector( new List<IFlightFilter>{ this._firstFilter.Object, this._secondFilter.Object });
        }

        [Test]
        public void ShouldOnlyReturnTheNotFilteredOutFlights()
        {
            IList<Flight> flights = this.GetFlights();

            this._firstFilter.SetupSequence(_ => _.ShouldBeFilterOut(It.IsAny<Flight>()))
                .Returns(true)
                .Returns(false);

            this._secondFilter.Setup(_ => _.ShouldBeFilterOut(It.IsAny<Flight>()))
                .Returns(false);

            IList<Flight> selectedFlights = this._flightSelector.Select(flights);

            Assert.That(selectedFlights.Count, Is.EqualTo(1));
        }


        private IList<Flight> GetFlights()
        {
            var flight1 = new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = DateTime.Today,
                        ArrivalDate = DateTime.Today.AddDays(1)
                    }
                }
            };

            var flight2 = new Flight
            {
                Segments = new List<Segment>
                {
                    new Segment
                    {
                        DepartureDate = DateTime.Today,
                        ArrivalDate = DateTime.Today.AddDays(3)
                    }
                }
            };


            return new List<Flight> { flight1, flight2 };
        }
    }
}
