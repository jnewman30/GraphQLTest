using GraphLib.GraphModel;
using GraphLib.Interfaces;
using GraphLib.Model;
using GraphQL.Types;

namespace GraphLib
{
    public class UserMutation : ObjectGraphType, IUserMutation
    {
        public UserMutation(IUserRepo userRepo)
        {
            UserRepo = userRepo;

            Field<UserGraphType>("update",
                                 arguments: new QueryArguments(
                                     new QueryArgument<StringGraphType> {Name = "id"},
                                     new QueryArgument<StringGraphType> {Name = "firstName"}),
                                 resolve: UpdateUser);
        }

        private IUserRepo UserRepo { get; }

        private User UpdateUser(ResolveFieldContext<object> arg)
        {
            return null;
        }
    }
}
