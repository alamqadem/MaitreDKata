using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaitreDKata
{
    public class TableConfigurationsGenerator : ITableConfigurationsGenerator
    {
        public IEnumerable<TableGroup> Generate(IEnumerable<ITable> tables)
        {
            var circTables = tables.Where(t => t is CircularTable);
            var rectTables = tables.Where(t => t is RectangularTable);

            return circTables
                    .Select(t => new TableGroup(new[] { t }))
                    .Concat(GenerateAux(rectTables));
        }

        private IEnumerable<TableGroup> GenerateAux(IEnumerable<ITable> tables)
        {
            // generates the powerset of tables
            if (!tables.Any())
                return new[] { new TableGroup(new ITable[0]) };

            var firstTable = tables.First();

            var alternativeConfigs = GenerateAux(tables.Skip(1));

            return alternativeConfigs
                    .Select(tblGroup =>
                            new TableGroup(
                                tblGroup.Concat(new[] { firstTable })))
                    .Concat(alternativeConfigs);
        }
    }
}
