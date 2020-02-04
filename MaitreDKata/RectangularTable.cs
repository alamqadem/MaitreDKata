using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    public class RectangularTable : Table
    {
        public RectangularTable(int size) : base(size)
        { }

        public override string ToString()
        {
            return $"|{Size}|";
        }
    }
}
