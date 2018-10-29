using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace DataLib.Model
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        [Computed]
        public IEnumerable<User> Users { get; set; }
    }
}
