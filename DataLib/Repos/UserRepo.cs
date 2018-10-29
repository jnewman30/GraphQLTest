using Dapper;
using DataLib.Model;

namespace DataLib.Repos
{
    public class UserRepo : RepoBase<User, string>, IUserRepo
    {
        public UserRepo(IMasterDb masterDb) : base(masterDb)
        {
        }

        public User GetByEmail(string email)
        {
            using (var conn = MasterDb.GetConnection())
            {
                return conn.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Email = @email", new { email });
            }
        }
    }
}