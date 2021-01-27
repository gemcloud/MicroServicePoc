using System.Collections.Generic;

namespace AuthService.Entities
{
    public class Users
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Avatar { get; private set; }
        public List<string> AvailableProducts { get; private set; }

        public Users(string login, string password, string avatar, List<string> availableProducts)
        {
            Login = login;
            Password = password;
            Avatar = avatar;
            AvailableProducts = availableProducts;
        }

        public bool PasswordMatches(string passwordToTest) => Password == passwordToTest;

    }
}
