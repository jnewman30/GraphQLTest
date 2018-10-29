using Dapper.Contrib.Extensions;

namespace DataLib.Model
{
    public class DataAdapter
    {
        [Key]
        public int Id { get; set; }

        public int AdapterTypeId { get; set; }

        public string Name { get; set; }

        public bool IsRowActive { get; set; }

        [Computed]
        public DataAdapterTypes AdapterType { get; set; }
    }
}