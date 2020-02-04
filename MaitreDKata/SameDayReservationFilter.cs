using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaitreDKata
{
    public class SameDayReservationFilter : IReservationFilter
    {
        public IEnumerable<IReservation> Filter(
            IEnumerable<IReservation> reservations, IReservation candidate, 
            TimeSpan seatingDuration)
        {
            return reservations
                    .Where(r =>
                           r.DateAndTime.Date == candidate.DateAndTime.Date);
        }
    }
}
