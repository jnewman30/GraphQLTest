using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLib.Model;
using DataLib.Repos;
using DataLib.Repos.ExternalData;
using GraphLib.DynamicModel;
using GraphLib.Interfaces;
using GraphLib.Model.Data;
using GraphLib.Model.User;
using GraphQL.Types;
using Newtonsoft.Json;

namespace GraphLib
{
    public class RootQuery : ObjectGraphType, IRootQuery
    {
        public RootQuery(IUserRepo userRepo, IDataAdapterRepo dataAdapterRepo)
        {
            UserRepo = userRepo;
            DataAdapterRepo = dataAdapterRepo;

            Field<ListGraphType<UserGraphType>>("users", resolve: GetAllUsers);

            Field<DynamicDataTableGraphType>("table",
                                             arguments: new QueryArguments(
                                                 new QueryArgument<StringGraphType> {Name = "name"}
                                             ),
                                             resolve: QueryTable);

            Field<DataAdapterGraphType>("dataAdapter",
                                        arguments: new QueryArguments(
                                            new QueryArgument<StringGraphType> { Name = "name" }
                                        ),
                                        resolve: QueryDataAdapterByName);

            Field<DataAdapterResultGraphType>("externalData",
                                        arguments: new QueryArguments(
                                            new QueryArgument<StringGraphType> { Name = "adapterName" },
                                            new QueryArgument<StringGraphType> { Name = "parameters" }
                                        ),
                                        resolve: QueryDataAdapter);
        }

        private IUserRepo UserRepo { get; }
        private IDataAdapterRepo DataAdapterRepo { get; }

        private async Task<DataAdapterResult> QueryDataAdapter(ResolveFieldContext<object> context)
        {
            var name = context.GetArgument<string>("adapterName");
            var parameters = context.GetArgument<string>("parameters");
            var paramObj = JsonConvert.DeserializeObject(parameters);
            var result = await DataAdapterRepo.QueryDataAdapterAsync(name, paramObj);
            return result;
        }

        private IDataAdapter QueryDataAdapterByName(ResolveFieldContext<object> context)
        {
            var name = context.GetArgument<string>("name");

            var dataAdapter = DataAdapterRepo.GetByName(name);

            return dataAdapter;
        }

        private IEnumerable<User> GetAllUsers(ResolveFieldContext<object> context)
        {
            return UserRepo.GetAll();
        }

        private DynamicDataTable QueryTable(ResolveFieldContext<object> context)
        {
            var name = context.GetArgument<string>("name");

            var tables = new List<DynamicDataTable>
                         {
                             new DynamicDataTable
                             {
                                 Name = "users",
                                 InternalName = "Users",
                                 Fields = new List<DynamicField>
                                          {
                                              new DynamicField
                                              {Name = "Id", InternalName = "Id", Type = DynamicFieldType.Number},
                                              new DynamicField
                                              {
                                                  Name = "UserName", InternalName = "UserName",
                                                  Type = DynamicFieldType.Text
                                              }
                                          }
                             },

                             new DynamicDataTable
                             {
                                 Name = "roles",
                                 InternalName = "Roles",
                                 Fields = new List<DynamicField>
                                          {
                                              new DynamicField
                                              {Name = "Id", InternalName = "Id", Type = DynamicFieldType.Number},
                                              new DynamicField
                                              {Name = "Name", InternalName = "Name", Type = DynamicFieldType.Text}
                                          }
                             }
                         };

            return tables.FirstOrDefault(t => t.Name == name);
        }
    }
}
