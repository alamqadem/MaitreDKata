using System;
using System.Collections.Generic;
using System.Text;

namespace MaitreDKata
{
    public interface ITableConfigurationsGenerator
    {
        IEnumerable<TableGroup> Generate(IEnumerable<ITable> tables);
    }
}
