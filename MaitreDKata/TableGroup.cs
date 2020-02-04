using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaitreDKata
{
    public class TableGroup : ITable, IEnumerable<ITable>
    {
        private readonly IEnumerable<ITable> tables;

        public TableGroup(IEnumerable<ITable> tables)
        {
            if (tables.Count() > 1 && !tables.All(t => t is RectangularTable))
                throw new Exception("Invalid table group");

            this.tables = tables;
        }

        public int Size => Tables.Sum(t => t.Size);

        private IEnumerable<ITable> Tables => tables;

        public IEnumerator<ITable> GetEnumerator() => Tables.GetEnumerator();

        public override string ToString() => String.Join(", ", Tables);

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
