using DataLib.Model;

namespace DataLib.Repos.ExternalData
{
    public interface IDataAdapterFactory
    {
        IDataAdapterStrategy GetAdapterStrategy(DataAdapterTypes adapterType);
    }
}