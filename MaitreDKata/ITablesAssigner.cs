using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    interface ITablesAssigner
    {
        IEnumerable<ITable> Assign(
            IEnumerable<IReservation> reservations, IEnumerable<ITable> tables);
    }
}
