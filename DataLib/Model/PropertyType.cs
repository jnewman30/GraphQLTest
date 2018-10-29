using Dapper.Contrib.Extensions;

namespace DataLib.Model
{
    public class PropertyType
    {
        [Key]
        public int Id { get; set; }

        [Computed]
        public PropertyTypes Enum { get; set; }

        public string Name { get; set; }

        public bool IsRowActive { get; set; }
    }
}