using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaitreDKata
{
    public class SameIntervalReservationFilter : IReservationFilter
    {
        public IEnumerable<IReservation> Filter(
            IEnumerable<IReservation> reservations, IReservation candidate, 
            TimeSpan seatingDuration)
        {
            return reservations
                    .Where(r =>
                            r.DateAndTime <= candidate.DateAndTime
                            &&
                            candidate.DateAndTime < r.DateAndTime + seatingDuration);
        }
    }
}
