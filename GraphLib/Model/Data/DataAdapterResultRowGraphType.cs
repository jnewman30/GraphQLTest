using DataLib.Model;
using GraphQL.Types;

namespace GraphLib.Model.Data
{
    public class DataAdapterResultRowGraphType : ObjectGraphType<DataAdapterResultRow>
    {
        public DataAdapterResultRowGraphType()
        {
            Field(x => x.Fields, type: typeof(ListGraphType<KeyValuePairGraphType>));
        }
    }
}
