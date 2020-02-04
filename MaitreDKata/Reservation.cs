using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    public class Reservation : IReservation
    {
        private readonly DateTime date;
        private readonly int quantity;

        public DateTime DateAndTime => date;

        public int Quantity => quantity;

        public Reservation(int quantity, DateTime date)
        {
            if (date == null)
                throw new ArgumentNullException(nameof(date));

            this.date = date;
            this.quantity = quantity;
        }

        public bool CanFit(ITable table)
        {
            return this.Quantity <= table.Size;
        }

        public override string ToString()
        {
            return $"[x{Quantity} - {DateAndTime}]";
        }
    }
}
