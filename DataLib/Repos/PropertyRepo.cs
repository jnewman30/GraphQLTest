using DataLib.Model;

namespace DataLib.Repos
{
    public class PropertyRepo : RepoBase<Property, int>, IPropertyRepo
    {
        public PropertyRepo(IMasterDb masterDb) : base(masterDb)
        {
        }
    }
}