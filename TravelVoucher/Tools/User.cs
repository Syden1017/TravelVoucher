using System.Collections.Generic;

namespace TravelVoucher.Tools
{
    public class User
    {
        public string login;

        public string password;

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public User(string login, 
                    string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}