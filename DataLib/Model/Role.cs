using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace DataLib.Model
{
    [Table("Roles")]
    public class Role
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
