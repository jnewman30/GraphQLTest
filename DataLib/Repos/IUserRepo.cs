using DataLib.Model;

namespace DataLib.Repos
{
    public interface IUserRepo : IRepo<User, string>
    {
        User GetByEmail(string email);
    }
}