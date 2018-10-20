using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataLib
{
    public class MasterDb : IMasterDb
    {
        public MasterDb(IConfiguration config)
        {
            Config = config;
        }

        private IConfiguration Config { get; }

        private string ConnectionString => Config.GetConnectionString("master");

        public IDbConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
