using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    public class Table : ITable
    {
        private readonly int size;

        public int Size => size;

        public Table(int size)
        {
            this.size = size;
        }
    }
}
