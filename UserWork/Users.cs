using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using static UserWork.Users;

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
            public List<User> users;

            public UserDataBase()
            {
                users = new List<User>
                {
                    new User("User", "12345")
                };
            }

            /// <summary>
            /// ���������� ������ ������������
            /// </summary>
            /// <param name="login">��� ������������ ��� ����� � �������</param>
            /// <param name="password">������ ������������ ��� ����� � �������</param>
            public void AddUser(string login, string password)
            {
                User user = new User(login, password);
                users.Add(user);
            }

            /// <summary>
            /// �������� �� ���������� �������� ������ ��� ����������� � �������������� � ������
            /// </summary>
            /// <param name="login">��� ������������ ��� ����� � �������</param>
            /// <param name="password">������ ������������ ��� ����� � �������</param>
            /// <returns>������ ��� ����</returns>
            public bool CheckUser(string login, string password)
            {
                return users.Exists(user => user.Login == login && user.Password == password);
            }

            /// <summary>
            /// �������� �� ���������� ��������� ������ ��� ����������� � ������� ������������ � ������
            /// </summary>
            /// <param name="login">��� ������������ ��� ����� � �������</param>
            /// <returns>������ ��� ����</returns>
            public bool CheckLogin(string login)
            {
                return users.Exists(user => user.Login == login);
            }

            /// <summary>
            /// �������� �� ���������� �������� ������ ��� ����������� � �������������� � ������
            /// </summary>
            /// <param name="password">������ ������������ ��� ����� � �������</param>
            /// <returns>������ ��� ����</returns>
            public bool CheckPassword(string password)
            {
                return users.Exists(user => user.Password == password);
            }

            public List<User> GetUsers()
            {
                return users;
            }
        }
    }
}
