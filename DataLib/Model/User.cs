using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace DataLib.Model
{
    [Table("Users")]
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        [Computed]
        public IEnumerable<Role> Roles { get; set; }
    }
}
