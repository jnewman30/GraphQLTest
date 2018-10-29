using System.Collections.Generic;
using DataLib.Model;
using DataLib.Repos;
using GraphLib.Model.User;
using GraphQL.Types;

namespace GraphLib
{
    public class RootQuery : ObjectGraphType, IRootQuery
    {
        public RootQuery(IUserRepo userRepo)
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