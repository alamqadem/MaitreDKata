using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaitreDKata
{
    public class AlternativeConfigurationsTableAssigner : ITablesAssigner
    {
        public IEnumerable<ITable> Assign(
            IEnumerable<IReservation> reservations, IEnumerable<ITable> tables)
        {
            if (!reservations.Any())
                return new ITable[0];

            var assignedTables = AssignTables(reservations.First(), tables);

            if (!assignedTables.Any())
                throw new Exception("Cannot assign tables to the reservations");

            return assignedTables
                    .Concat(
                        Assign(reservations.Skip(1),
                          tables.Except(assignedTables)));
        }

        private IEnumerable<ITable> AssignTables(
            IReservation reservation, IEnumerable<ITable> tables)
        {
            // assign a circular table
            var circTable = AssignCircular(reservation, tables);
            if (circTable != null)
                return new[] { circTable };

            // assign a rectangular table
            var rectTable = AssignTable(reservation, tables);
            if (rectTable != null)
                return new[] { rectTable };

            // assign a set of rectangular tables whose sum is equal to the
            // quantity of the reservation
            var tblGroup = AssignAlternativeConfiguration(reservation, tables);

            return tblGroup;
        }

        private ITable AssignCircular(
            IReservation reservation, IEnumerable<ITable> tables)
        {
            var circularTables = tables.Where(t => t is CircularTable);

            return AssignTable(reservation, circularTables);
        }

        private ITable AssignRectangular(
            IReservation reservation, IEnumerable<ITable> tables)
        {
            var rectangularTables = tables.Where(t => t is RectangularTable);

            return AssignTable(reservation, rectangularTables);
        }

        private IEnumerable<ITable> AssignAlternativeConfiguration(
            IReservation reservation, IEnumerable<ITable> tables)
        {
            var rectangularTables = tables.Where(t => t is RectangularTable);

            var alternativeConfigs = new TableConfigurationsGenerator()
                                        .Generate(rectangularTables);

            // choose a configuration
            var assignedTbl = AssignTable(reservation, alternativeConfigs);

            if (assignedTbl == null
                || !(assignedTbl is TableGroup assignedTblGroup))
                return new ITable[0];

            // return the selected tables in that configuration
            return assignedTblGroup;
        }
        
        private ITable AssignTable(
            IReservation reservation, IEnumerable<ITable> tables)
        {
            if (!tables.Any())
                return null;

            var minEmptySeats = tables
                                    .Where(t => reservation.CanFit(t))
                                    .Min(t => (int?) t.Size - reservation.Quantity);

            if (minEmptySeats == null)
                return null;

            return tables
                    .FirstOrDefault(
                        t => t.Size == (minEmptySeats + reservation.Quantity));
        }
    }
}
