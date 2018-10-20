using System.Collections.Generic;
using DataLib.Model;

namespace DataLib.Repos
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAll();

        User GetById(string id);

        User GetByEmail(string email);

        User Create(User user);
    }
}
