using GraphLib.Interfaces;
using GraphQL.Types;

namespace GraphLib
{
    public class MasterSchema : Schema, IMasterSchema
    {
        public MasterSchema(
            IUserQuery userQuery, 
            IUserMutation userMutation)
        {
            Query = userQuery;
            Mutation = userMutation;
        }
    }
}
