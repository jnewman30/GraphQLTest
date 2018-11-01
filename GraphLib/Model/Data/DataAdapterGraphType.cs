using DataLib.Model;
using GraphQL.Types;

namespace GraphLib.Model.Data
{
    public class DataAdapterGraphType : ObjectGraphType<DataAdapter>
    {
        public DataAdapterGraphType()
        {
            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.AdapterTypeId, type: typeof(IntGraphType));
            Field(x => x.IsRowActive, type: typeof(BooleanGraphType));
            Field(x => x.Endpoint, type: typeof(StringGraphType));
            Field(x => x.Metadata, type: typeof(StringGraphType));

            Field(x => x.AdapterType, type: typeof(DataAdapterTypeGraphType));
        }
    }
}
