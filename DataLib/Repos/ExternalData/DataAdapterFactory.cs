using System;
using DataLib.Model;

namespace DataLib.Repos.ExternalData
{
    public class DataAdapterFactory : IDataAdapterFactory
    {
        public DataAdapterFactory(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        private IServiceProvider ServiceProvider { get; }

        public IDataAdapterStrategy GetAdapterStrategy(DataAdapterTypes adapterType)
        {
            switch (adapterType)
            {
                case DataAdapterTypes.GraphQL:
                    return (IDataAdapterStrategy) ServiceProvider.GetService(typeof(GraphQLDataAdapter));

                default:
                    var adapterName = Enum.GetName(typeof(DataAdapterTypes), adapterType);
                    throw new ArgumentOutOfRangeException($"No Data Adapter Strategy found for \"{adapterName}\".");
            }
        }
    }
}
