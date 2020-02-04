using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaitreDKata
{
    public class SecondSeatingsMaitreD : IMaitreD
    {
        public bool Accept(
            IReservation[] reservations, IReservation candidate,
            ITable[] tables, TimeSpan seatingDuration)
        {
            var sameDayReservations = new SameIntervalReservationFilter()
                                        .Filter(reservations, candidate, 
                                                seatingDuration);

            var assignedTables = new BestFitTableAssigner()
                                    .Assign(sameDayReservations, tables);

            var leftTables = tables.Except(assignedTables);

            return leftTables.Any(t => candidate.CanFit(t));
        }
    }
}
