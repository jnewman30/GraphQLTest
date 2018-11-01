using System.Data;
using Dapper.Contrib.Extensions;

namespace DataLib.Model
{
    public class DataAdapter : IDataAdapter
    {
        [Key]
        public int Id { get; set; }

        public int AdapterTypeId { get; set; }

        public string Name { get; set; }

        public string Endpoint { get; set; }

        public string Metadata { get; set; }

        public bool IsRowActive { get; set; }

        [Computed]
        public DataAdapterType AdapterType { get; set; }
    }
}