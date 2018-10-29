using DataLib.Model;

namespace DataLib.Repos
{
    public class DataAdapterRepo : RepoBase<DataAdapter, int>, IDataAdapterRepo
    {
        public DataAdapterRepo(IMasterDb masterDb) : base(masterDb)
        {
        }
    }
}