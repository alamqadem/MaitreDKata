using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    interface IMaitreD
    {
        bool Accept(IReservation[] reservations, IReservation candidate, 
                    ITable[] tables, TimeSpan seatingDuration);
    }
}
