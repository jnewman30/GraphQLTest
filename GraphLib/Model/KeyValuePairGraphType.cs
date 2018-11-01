using System.Collections.Generic;
using GraphQL.Types;

namespace GraphLib.Model
{
    public class KeyValuePairGraphType : ObjectGraphType<KeyValuePair<string, string>>
    {
        public KeyValuePairGraphType()
        {
            Field(x => x.Key, type: typeof(StringGraphType));
            Field(x => x.Value, type: typeof(StringGraphType));
        }
    }
}