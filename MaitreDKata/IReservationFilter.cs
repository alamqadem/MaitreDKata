using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    interface IReservationFilter
    {
        IEnumerable<IReservation> Filter(
            IEnumerable<IReservation> reservations, IReservation candidate,
            TimeSpan seatingDuration);
    }
}
