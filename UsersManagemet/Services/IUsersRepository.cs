using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersManagement.Services
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User Add(User newUser);
        User GetUserById(int id);
        void DeleteUserById(int id);
    }
}
