using GraphLib.Model;
using GraphQL.Types;

namespace GraphLib.DynamicModel
{
    public class DynamicDataRowGraphType : ObjectGraphType<DynamicDataRow>
    {
        public DynamicDataRowGraphType()
        {
            Field(x => x.Fields, type: typeof(ListGraphType<KeyValuePairGraphType>));
        }
    }
}