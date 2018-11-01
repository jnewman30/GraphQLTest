using System.Collections.Generic;
using System.Threading.Tasks;
using DataLib.Model;

namespace DataLib.Repos.ExternalData
{
    public interface IDataAdapterRepo : IRepo<DataAdapter, int>
    {
        IDataAdapter GetByName(string name);

        Task<DataAdapterResult> QueryDataAdapterAsync(string name, dynamic parameters);
    }
}