using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaitreDKata
{
    public class AlternativeTableConfigurationsMaitreD : IMaitreD
    {
        public bool Accept(
            IReservation[] reservations, IReservation candidate, 
            ITable[] tables, TimeSpan seatingDuration)
        {
            var sameDayReservations = new SameIntervalReservationFilter()
                                        .Filter(reservations, candidate,
                                                seatingDuration);

            var assignedTables = new AlternativeConfigurationsTableAssigner()
                                       .Assign(sameDayReservations, tables);

            var leftTables = tables.Except(assignedTables);

            var leftTblsGroups = new TableConfigurationsGenerator()
                                    .Generate(leftTables);

            return leftTblsGroups.Any(t => candidate.CanFit(t));
        }
    }
}
