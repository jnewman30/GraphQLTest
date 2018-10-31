using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GraphQL.Types;

namespace GraphLib.DynamicModel
{
    public class DynamicTableGraphType : ObjectGraphType<DynamicTable>
    {
        public DynamicTableGraphType()
        {
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.InternalName, type: typeof(StringGraphType));
            Field(x => x.Fields, type: typeof(ListGraphType<DynamicFieldGraphType>));
            Field("data", x => QueryTable(x), type: typeof(ListGraphType<DynamicDataRowGraphType>));
        }

        private IEnumerable<DynamicDataRow> QueryTable(DynamicTable x)
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
                    var row = new DynamicDataRow() { Fields = fields };
                    items.Add(row);
                }
                return items;
            }
        }
    }

    public class DynamicDataRow
    {
        public IEnumerable<KeyValuePair<string, string>> Fields { get; set; }
    }

    public class DynamicDataRowGraphType : ObjectGraphType<DynamicDataRow>
    {
        public DynamicDataRowGraphType()
        {
            Field(x => x.Fields, type: typeof(ListGraphType<DynamicDataGraphType>));
        }
    }

    public class DynamicDataGraphType : ObjectGraphType<KeyValuePair<string, string>>
    {
        public DynamicDataGraphType()
        {
            Field(x => x.Key, type: typeof(StringGraphType));
            Field(x => x.Value, type: typeof(StringGraphType));
        }
    }
}