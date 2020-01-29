using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    public class QuantityOnlyReservation : IReservation
    {
        private readonly int quantity;

        DateTime IReservation.Date => throw new NotImplementedException();

        int IReservation.Quantity => quantity;

        public QuantityOnlyReservation(int quantity)
        {
            this.quantity = quantity;
        }
    }
}
