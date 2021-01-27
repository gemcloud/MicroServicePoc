using AuthService.Entities;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AuthService.DataAccess
{
    public class DummyUsersInMemoryDb : IUsers
    {
        private readonly IDictionary<string, Users> db = new ConcurrentDictionary<string, Users>();

        public DummyUsersInMemoryDb()
        {
            Add(new Users("gem@gmail.com", "password", "static/avatars/gem.png", new List<string>() { "TRI", "HSI", "FAI", "CAR" }));
            Add(new Users("cloud@gmail.com", "secret", "static/avatars/cloud.png", new List<string>() { "TRI", "HSI", "FAI", "CAR" }));
            Add(new Users("admin", "admin", "static/avatars/admin.png", new List<string>() { "TRI", "HSI", "FAI", "CAR" }));
        }

        public void Add(Users user)
        {
            db[user.Login] = user;
        }

        public Users FindByLogin(string login) => db[login];

    }
}
