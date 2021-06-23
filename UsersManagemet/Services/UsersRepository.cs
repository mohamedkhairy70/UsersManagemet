using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersManagement.Services
{
    public record User (int Id,string Name,int Age,string Address);
    public class UsersRepository : IUsersRepository
    {
        private List<User> Users { get; } = new();

        public User Add(User newUser)
        {
            Users.Add(newUser);
            return newUser;
        }

        public void DeleteUserById(int id)
        {
            var ExistingUser = GetUserById(id);
            if(ExistingUser == null)
            {
                throw new ArgumentException("No Access User Given Id",nameof(id));
            }
            Users.Remove(ExistingUser);
        }

        public User GetUserById(int id) => Users.FirstOrDefault(u => u.Id == id);

        public IEnumerable<User> GetUsers() => Users;
    }
}
