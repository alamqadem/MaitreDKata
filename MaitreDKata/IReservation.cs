using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    public interface IReservation
    {
        DateTime DateAndTime { get; }
        int Quantity { get; }

        bool CanFit(ITable table);
    }
}
