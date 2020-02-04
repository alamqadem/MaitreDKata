using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    public class CircularTable : Table
    {
        public CircularTable(int size) : base(size)
        { }

        public override string ToString()
        {
            return $"({Size})";
        }
    }
}
