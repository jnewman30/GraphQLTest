using System.Collections.Generic;
using System.Threading.Tasks;
using DataLib.Model;

namespace DataLib.Repos.ExternalData
{
    public interface IDataAdapterStrategy
    {
        Task<DataAdapterResult> Read(IDataAdapter dataAdapter, dynamic parameters);
    }
}