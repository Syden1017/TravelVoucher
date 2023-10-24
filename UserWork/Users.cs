using System;
using System.Collections.Generic;

namespace UserWork
{
    public class Users
    {
        public class User
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }

        public class UserDataBase
        {
            private List<User> users;

            public UserDataBase()
            {
                users = new List<User>
                {
                    new User { Login = "User", Password = "12345" },
                };
            }

            /// <summary>
            /// Добавление нового пользователя
            /// </summary>
            /// <param name="username">Имя пользователя для входа в систему</param>
            /// <param name="password">Пароль пользователя для входа в систему</param>
            /// <exception cref="ArgumentException">Ошибка в случае, если пользователь уже существует</exception>
            public void AddUser(string username, string password)
            {
                // Проверяет есть ли пользоавтель в списке
                if (UserExists(username))
                {
                    throw new ArgumentException("Пользователь уже существует.");
                }

                users.Add(new User { Login = username, Password = password });
            }

            /// <summary>
            /// Проверка на наличие пользователя в системе
            /// </summary>
            /// <param name="username">Имя пользователя для входа в систему</param>
            /// <returns>Истина или ложь</returns>
            private bool UserExists(string username)
            {
                foreach (var user in users)
                {
                    if (user.Login == username)
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Проверка на совпадение введённых данных при авторизации с пользователями в списке
            /// </summary>
            /// <param name="login">Имя пользователя для входа в систему</param>
            /// <param name="password">Пароль пользователя для входа в систему</param>
            /// <returns>Истина или ложь</returns>
            public bool CheckUser(string login, string password)
            {
                return users.Exists(user => user.Login == login && user.Password == password);
            }

            /// <summary>
            /// Проверка на совпадение введённого логина при авторизации с логином пользователя в списке
            /// </summary>
            /// <param name="login">Имя пользователя для входа в систему</param>
            /// <returns>Истина или ложь</returns>
            public bool CheckLogin(string login)
            {
                return users.Exists(user => user.Login == login);
            }

            /// <summary>
            /// Проверка на совпадение введённых данных при авторизации с пользователями в списке
            /// </summary>
            /// <param name="password">Пароль пользователя для входа в систему</param>
            /// <returns>Истина или ложь</returns>
            public bool CheckPassword(string password)
            {
                return users.Exists(user => user.Password == password);
            }
        }
    }
}