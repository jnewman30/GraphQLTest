using GraphQL.Types;

namespace GraphLib.DynamicModel
{
    public class DynamicFieldGraphType : ObjectGraphType<DynamicField>
    {
        public DynamicFieldGraphType()
        {
            Field(x => x.Name, type: typeof(StringGraphType));
            Field(x => x.InternalName, type: typeof(StringGraphType));
            Field(x => x.Type, type: typeof(EnumerationGraphType<DynamicFieldType>));
        }
    }
}