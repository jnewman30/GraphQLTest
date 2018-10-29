using Dapper.Contrib.Extensions;

namespace DataLib.Model
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        public int PropertyTypeId { get;set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool IsRowActive { get; set; }

        [Computed]
        public PropertyType PropertyType { get; set; }
    }
}