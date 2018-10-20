using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GraphLib.Interfaces;
using GraphLib.Model;
using Newtonsoft.Json;

namespace GraphLib
{
    public class UserRepo : IUserRepo
    {
        private static List<User> Users { get; }

        static UserRepo()
        {
            if (Users != null)
            {
                return;
            }

            var assembly = typeof(UserRepo).GetTypeInfo().Assembly;
            using (var resource = assembly.GetManifestResourceStream("GraphLib.TestData.Users.json"))
            {
                using (var reader = new StreamReader(resource ?? throw new InvalidOperationException()))
                {
                    var userData = reader.ReadToEnd();
                    Users = JsonConvert.DeserializeObject<List<User>>(userData);
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            return Users.ToArray();
        }

        public User GetById(string id)
        {
            return Users.FirstOrDefault(user => user.Id == id);
        }

        public User GetByEmail(string email)
        {
            return Users.FirstOrDefault(user => user.Email == email);
        }
    }
}
