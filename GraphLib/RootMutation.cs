using System;
using DataLib.Model;
using DataLib.Repos;
using GraphLib.Interfaces;
using GraphLib.Model.User;
using GraphQL.Types;

namespace GraphLib
{
    public class RootMutation : ObjectGraphType, IRootMutation
    {
        public RootMutation(IUserRepo userRepo)
        {
            UserRepo = userRepo;

            Field<UserGraphType>("create",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "userName" },
                    new QueryArgument<StringGraphType> { Name = "email" },
                    new QueryArgument<StringGraphType> { Name = "firstName" },
                    new QueryArgument<StringGraphType> { Name = "lastName" },
                    new QueryArgument<StringGraphType> { Name = "company" }),
                resolve: CreateUser);
        }

        private IUserRepo UserRepo { get; }

        private User CreateUser(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<string>("id");
            var userName = context.GetArgument<string>("userName");
            var email = context.GetArgument<string>("email");
            var firstName = context.GetArgument<string>("firstName");
            var lastName = context.GetArgument<string>("lastName");
            var company = context.GetArgument<string>("company");

            return UserRepo.Create(new User
            {
                Id = id,
                UserName = userName,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Company = company,
                DateCreated = DateTime.Now
            });
        }
    }
}