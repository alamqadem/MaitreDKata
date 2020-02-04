using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaitreDKata
{
    public class BestFitTableAssigner : ITablesAssigner
    {
        public IEnumerable<ITable> Assign(
            IEnumerable<IReservation> reservations, IEnumerable<ITable> tables)
        {
            if (!reservations.Any())
                return new ITable[0];

            var assignedTable = AssignTable(reservations.First(), tables);

            if (assignedTable == null)
                throw new Exception("Cannot assign tables to the reservations");

            return Assign(reservations.Skip(1),
                                tables.Except(new[] { assignedTable }))
                   .Concat(new[] { assignedTable });
        }

        private ITable AssignTable(IReservation reservation,
                                   IEnumerable<ITable> tables)
        {
            var minEmptySeats = tables
                                    .Where(t => reservation.CanFit(t))
                                    .Min(t => t.Size - reservation.Quantity);
            return tables
                    .FirstOrDefault(
                        t => t.Size == (minEmptySeats + reservation.Quantity));
        }

        
    }
}
