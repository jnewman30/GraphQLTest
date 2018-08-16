using System.Collections.Generic;
using GraphQL.Types;

namespace GraphQLTest.Schemas.Dynamic
{
    public class DynamicQuery : ObjectGraphType
    {
        public DynamicQuery()
        {
            Field<ListGraphType<DynamicTableModel>>("tables", resolve: GetTables);
        }

        private List<DynamicTable> GetTables(ResolveFieldContext<object> context)
        {
            return new List<DynamicTable>
                   {
                       new DynamicTable
                       {
                           Id = 1,
                           Name = "Table1",
                           Fields = new List<DynamicField>
                                    {
                                        new DynamicField
                                        {
                                            Name = "field1",
                                            Type = "String"
                                        }
                                    }
                       }
                   };
        }
    }

    public class DynamicField
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }

    public class DynamicFieldModel : ObjectGraphType<DynamicField>
    {
        public DynamicFieldModel()
        {
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.Type, type: typeof(StringGraphType));
        }
    }

    public class DynamicTable
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<DynamicField> Fields { get; set; } = new List<DynamicField>();
    }

    public class DynamicTableModel : ObjectGraphType<DynamicTable>
    {
        public DynamicTableModel()
        {
            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.Fields, type: typeof(ListGraphType<DynamicFieldModel>));
        }
    }
}
