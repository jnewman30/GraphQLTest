using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GraphQL.Types;

namespace GraphLib.DynamicModel
{
    public class DynamicDataTableGraphType : ObjectGraphType<DynamicDataTable>
    {
        public DynamicDataTableGraphType()
        {
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.InternalName, type: typeof(StringGraphType));
            Field(x => x.Fields, type: typeof(ListGraphType<DynamicFieldGraphType>));
            Field("data", x => QueryTable(x), type: typeof(ListGraphType<DynamicDataRowGraphType>));
        }

        private IEnumerable<DynamicDataRow> QueryTable(DynamicDataTable x)
        {
            var connStr = "Server=.;Database=GraphTest;Trusted_Connection=True";
            using (var conn = new SqlConnection(connStr))
            {
                var results = conn.Query($"SELECT * FROM {x.InternalName}");
                var items = new List<DynamicDataRow>();
                foreach (var item in results)
                {
                    var dic = (IEnumerable<KeyValuePair<string, object>>) item;
                    var fields = dic.Select(fld => new KeyValuePair<string, string>(fld.Key, fld.Value.ToString()));
                    var row = new DynamicDataRow {Fields = fields};
                    items.Add(row);
                }

                return items;
            }
        }
    }
}
