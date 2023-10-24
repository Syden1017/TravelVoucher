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

        public override string ToString()
        {
            string result = $"Login: {Login}\n" +
                            $"Password: {Password}";

            return result;
        }
    }
}