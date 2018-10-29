using Dapper.Contrib.Extensions;

namespace DataLib.Model
{
    public class DataAdapterType
    {
        [Key]
        public int Id { get; set; }

        [Computed]
        public DataAdapterTypes Enum { get; set; }

        public string Name { get; set; }

        public bool IsRowActive { get; set; }
    }
}