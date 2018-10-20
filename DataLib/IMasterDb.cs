using System.Data;

namespace DataLib
{
    public interface IMasterDb
    {
        IDbConnection GetConnection();
    }
}
