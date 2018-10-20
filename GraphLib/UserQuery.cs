using System.Collections.Generic;
using GraphLib.GraphModel;
using GraphLib.Interfaces;
using GraphLib.Model;
using GraphQL.Types;

namespace GraphLib
{
    public class UserQuery : ObjectGraphType, IUserQuery
    {
        public UserQuery(IUserRepo userRepo)
        {
            UserRepo = userRepo;

            Field<ListGraphType<UserGraphType>>("users", resolve: GetAllUsers);
        }

        private IUserRepo UserRepo { get; }

        private IEnumerable<User> GetAllUsers(ResolveFieldContext<object> context)
        {
            return UserRepo.GetAll();
        }
    }
}
