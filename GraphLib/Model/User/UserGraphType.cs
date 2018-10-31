using GraphQL.Types;

namespace GraphLib.Model.User
{
    public class UserGraphType : ObjectGraphType<DataLib.Model.User>
    {
        public UserGraphType()
        {
            Field(x => x.Id, type: typeof(StringGraphType));
            Field(x => x.UserName, type: typeof(StringGraphType));
            Field(x => x.Email, type: typeof(StringGraphType));
            Field(x => x.FirstName, type: typeof(StringGraphType));
            Field(x => x.LastName, type: typeof(StringGraphType));
            Field(x => x.Company, type: typeof(StringGraphType));
            Field(x => x.DateCreated, type: typeof(DateTimeGraphType));
        }
    }
}