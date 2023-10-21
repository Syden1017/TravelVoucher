using System;
using System.Collections.Generic;

namespace TravelVoucher.Tools
{
    public class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public User(string login, 
                    string password)
        {
            Login = login;
            Password = password;
        }

        public override bool Equals(object obj)
        {
            if (obj is User otherUser)
            {
                return Login == otherUser.Login &&
                       Password == otherUser.Password;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Login, Password);
        }

        public override string ToString()
        {
            string result = $"Login: {Login}\n" +
                            $"Password: {Password}";

            return result;
        }

        List<User> _users = new List<User>()
        { 
            new User("User", "12345")
        };
    }
}