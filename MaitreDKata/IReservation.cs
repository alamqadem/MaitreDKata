using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    public interface IReservation
    {
        DateTime Date { get; }
        int Quantity { get; }
    }
}
