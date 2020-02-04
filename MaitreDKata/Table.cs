using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    public abstract class Table : ITable
    {
        private readonly int size;

        public int Size => size;

        public Table(int size)
        {
            this.size = size;
        }

        public abstract override string ToString();
    }
}
