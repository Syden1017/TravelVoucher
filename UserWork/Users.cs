using System;
using System.Collections.Generic;
using System.Windows;

namespace UserWork
{
    public class Users
    {
        public class User
        {
            private string login;
            private string password;

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

            public User(string login, string password)
            {
                Login = login;
                Password = password;
            }
        }

        public class UserDataBase
        {
            private List<User> users;

            public UserDataBase()
            {
                users = new List<User>
                {
                    new User("User", "12345")
                };
            }

            /// <summary>
            /// Добавление нового пользователя
            /// </summary>
            /// <param name="login">Имя пользователя для входа в систему</param>
            /// <param name="password">Пароль пользователя для входа в систему</param>
            public void AddUser(string login, string password)
            {
                if (!CheckUser(login, password))
                {
                    users.Add(new User(login, password));
                }
                else
                {
                    MessageBox.Show(
                        "Пользователь уже существует",
                        "Ошибка регистрации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                }
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

            public void InitializeUsers(List<User> initialUsers)
            {
                users.AddRange(initialUsers);
            }
        }
    }
}