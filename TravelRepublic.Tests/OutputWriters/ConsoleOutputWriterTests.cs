using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.FlightCodingTest;
using TravelRepublic.OutputWriters;

namespace TravelRepublic.Tests.OutputWriters
{
    [TestFixture]
    class ConsoleOutputWriterTests
    {
        private Mock<IConsoleWrapper> _consoleMock;
        private IOutputWriter _outputWriter;

        [SetUp]
        public void Setup()
        {
            this._consoleMock = new Mock<IConsoleWrapper>();

            this._outputWriter = new ConsoleOutputWriter(this._consoleMock.Object);
        }


        [Test]
        public void ShouldCallTheConsoleObjectTheRightAmountOfTimes()
        {
            int timesWriteLineWithMessageGetsCalled = 3;
            int timesWriteLineWithNoMessageGetsCalled = 3;
            int timesWriteWithMessageGetsCalled = 2;

            IList<Flight> flights = this.GetFlights();
            this._consoleMock.Setup(_ => _.WriteLine(It.IsAny<string>())).Verifiable();
            this._consoleMock.Setup(_ => _.WriteLine()).Verifiable();
            this._consoleMock.Setup(_ => _.Write(It.IsAny<string>())).Verifiable();

            this._outputWriter.Write(flights);

            this._consoleMock.Verify(_ => _.WriteLine(It.IsAny<string>()), Times.Exactly(timesWriteLineWithMessageGetsCalled));
            this._consoleMock.Verify(_ => _.WriteLine(), Times.Exactly(timesWriteLineWithNoMessageGetsCalled));
            this._consoleMock.Verify(_ => _.Write(It.IsAny<string>()), Times.Exactly(timesWriteWithMessageGetsCalled));

        }

        private IList<Flight> GetFlights()
        {
            var flight = new Flight
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

            return new List<Flight> { flight };
        }
    }
}
