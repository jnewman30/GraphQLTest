using System;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using DataLib.Model;

namespace DataLib.Repos.ExternalData
{
    public class DataAdapterRepo : RepoBase<DataAdapter, int>, IDataAdapterRepo
    {
        public DataAdapterRepo(
            IMasterDb masterDb,
            IDataAdapterFactory dataAdapterFactory)
            : base(masterDb)
        {
            DataAdapterFactory = dataAdapterFactory;
        }

        private IDataAdapterFactory DataAdapterFactory { get; }

        public IDataAdapter GetByName(string name)
        {
            using (var conn = MasterDb.GetConnection())
            {
                const string sql = "SELECT TOP 1 * FROM DataAdapters WHERE [Name] = @name";
                var dataAdapter = conn.QueryFirstOrDefault<DataAdapter>(sql, new { name });
                dataAdapter.AdapterType = conn.Get<DataAdapterType>(dataAdapter.AdapterTypeId);
                return dataAdapter;
            }
        }

        public async Task<DataAdapterResult> QueryDataAdapterAsync(string name, dynamic parameters)
        {
            var dataAdapter = GetByName(name);
            if (dataAdapter.AdapterType == null)
            {
                throw new InvalidOperationException($"Data Adapter \"{name}\" not found.");
            }

            var adapterType = dataAdapter.AdapterType.Enum;
            var adapterStrategy = DataAdapterFactory.GetAdapterStrategy(adapterType);
            if (adapterStrategy == null)
            {
                var adapterTypeName = Enum.GetName(typeof(DataAdapterTypes), adapterType);
                throw new InvalidOperationException($"Data Adapter Strategy for \"{adapterTypeName}\" not found.");
            }

            return await adapterStrategy.Read(dataAdapter, parameters);
        }
    }
}