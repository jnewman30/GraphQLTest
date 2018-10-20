using System.Collections.Generic;
using GraphLib.Model;

namespace GraphLib.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAll();
    }
}
