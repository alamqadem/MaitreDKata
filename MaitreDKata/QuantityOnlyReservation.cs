using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    public class QuantityOnlyReservation : IReservation
    {
        private readonly int quantity;

        DateTime IReservation.DateAndTime => throw new NotImplementedException();

        int IReservation.Quantity => quantity;

        public QuantityOnlyReservation(int quantity)
        {
            this.quantity = quantity;
        }

        public bool CanFit(ITable table)
        {
            return this.quantity <= table.Size;
        }
    }
}
