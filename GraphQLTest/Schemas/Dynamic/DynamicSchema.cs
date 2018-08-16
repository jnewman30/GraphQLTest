using GraphQL.Types;

namespace GraphQLTest.Schemas.Dynamic
{
    public class DynamicSchema : Schema
    {
        public DynamicSchema(DynamicQuery query)
        {
            Query = query;
        }
    }
}
