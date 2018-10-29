using GraphQL.Types;

namespace GraphLib
{
    public class MasterSchema : Schema, IMasterSchema
    {
        public MasterSchema(
            IRootQuery query, 
            IRootMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}