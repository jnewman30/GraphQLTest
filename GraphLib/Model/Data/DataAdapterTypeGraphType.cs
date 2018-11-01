using DataLib.Model;
using GraphQL.Types;

namespace GraphLib.Model.Data
{
    public class DataAdapterTypeGraphType : ObjectGraphType<DataAdapterType>
    {
        public DataAdapterTypeGraphType()
        {
            Field(x => x.Id, type: typeof(IntGraphType));
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.Enum, type: typeof(EnumerationGraphType<DataAdapterTypes>));
            Field(x => x.IsRowActive, type: typeof(BooleanGraphType));
        }
    }
}