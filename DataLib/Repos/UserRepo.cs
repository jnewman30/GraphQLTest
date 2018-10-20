using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;
using DataLib.Model;

namespace DataLib.Repos
{
    public class UserRepo : IUserRepo
    {
        public UserRepo(IMasterDb masterDb)
        {
            MasterDb = masterDb;
        }

        private IMasterDb MasterDb { get; }

        public IEnumerable<User> GetAll()
        {
            using (var conn = MasterDb.GetConnection())
            {
                return conn.GetAll<User>();
            }
        }

        public User Create(User user)
        {
            using (var conn = MasterDb.GetConnection())
            {
                var id = conn.Insert(user);
                return user;
            }
        }

        public User GetById(string id)
        {
            using (var conn = MasterDb.GetConnection())
            {
                return conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Id = @id", new {id});
            }
        }

        public User GetByEmail(string email)
        {
            using (var conn = MasterDb.GetConnection())
            {
                return conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Email = @email", new {email});
            }
        }
    }
}
