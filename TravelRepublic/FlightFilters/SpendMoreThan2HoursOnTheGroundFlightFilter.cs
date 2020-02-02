using System;
using System.Collections.Generic;
using System.Text;
using TravelRepublic.FlightCodingTest;

namespace TravelRepublic.FlightFilters
{    
    public class SpendMoreThan2HoursOnTheGroundFlightFilter : IFlightFilter
    {
        private int _totalNumberOfSegments;
        private readonly double _maximumHours = 2d;

        public bool ShouldBeFilterOut(Flight flight)
        {

            this._totalNumberOfSegments = flight.Segments.Count;

            if (this.ThereIsOnlyOneSegment())
                return false;

            for (int i = 0; i < this._totalNumberOfSegments; i++)
            {
                if (this.IsTheLastSegment(i))
                    return false;

                double hours = this.GetDifferenceInHours(flight.Segments[i + 1].DepartureDate, flight.Segments[i].ArrivalDate);                

                if (hours > this._maximumHours)
                    return true;
            }

            return false;
        }

        private double GetDifferenceInHours(DateTime nextDepartureDate, DateTime previousArrivalDate)
        {
            return (nextDepartureDate.Subtract(previousArrivalDate).TotalHours);

            
        }

        private bool ThereIsOnlyOneSegment()
        {
            return (this._totalNumberOfSegments < 2);
        }

        private bool IsTheLastSegment(int index)
        {
            return (index == this._totalNumberOfSegments - 1);
        }


    }
}
