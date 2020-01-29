using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaitreDKata
{
    public class MaitreD : IMaitreD
    {
        public bool Accept(IReservation[] reservations, IReservation candidate, 
                           ITable[] tables)
        {
            int total = reservations
                            .Where(r => r.Date.Equals(candidate.Date))
                            .Sum(r => r.Quantity) + candidate.Quantity;
            return total <= tables.Sum(t => t.Size);
        }
    }
}
