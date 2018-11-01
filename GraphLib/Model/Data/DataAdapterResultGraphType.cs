using DataLib.Model;
using GraphQL.Types;

namespace GraphLib.Model.Data
{
    public class DataAdapterResultGraphType : ObjectGraphType<DataAdapterResult>
    {
        public DataAdapterResultGraphType()
        {
            Field(x => x.Rows, type: typeof(ListGraphType<DataAdapterResultRowGraphType>));
        }
    }
}
