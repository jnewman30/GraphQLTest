using System.Collections.Generic;
using System.Linq;
using DataLib.Model;
using DataLib.Repos;
using GraphLib.DynamicModel;
using GraphLib.Interfaces;
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

            Field<DynamicTableGraphType>("table",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "name" }
                ),
                resolve: QueryTable);
        }

        private IUserRepo UserRepo { get; }

        private IEnumerable<User> GetAllUsers(ResolveFieldContext<object> context)
        {
            return UserRepo.GetAll();
        }

        private DynamicTable QueryTable(ResolveFieldContext<object> context)
        {
            var name = context.GetArgument<string>("name");

            var tables = new List<DynamicTable>
            {
                new DynamicTable
                {
                    Name = "users",
                    InternalName = "Users",
                    Fields = new List<DynamicField>
                    {
                        new DynamicField { Name = "Id", InternalName = "Id", Type = DynamicFieldType.Number },
                        new DynamicField { Name = "UserName", InternalName = "UserName", Type = DynamicFieldType.Text }
                    }
                },
                
                new DynamicTable
                {
                    Name = "roles",
                    InternalName = "Roles",
                    Fields = new List<DynamicField>
                    {
                        new DynamicField { Name = "Id", InternalName = "Id", Type = DynamicFieldType.Number },
                        new DynamicField { Name = "Name", InternalName = "Name", Type = DynamicFieldType.Text }
                    }
                }
            };

            return tables.FirstOrDefault(t => t.Name == name);
        }
    }
}