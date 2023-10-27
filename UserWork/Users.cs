using System;
using System.Collections.Generic;

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
                users = new List<User>();
            }

            /// <summary>
            /// ���������� ������ ������������
            /// </summary>
            /// <param name="login">��� ������������ ��� ����� � �������</param>
            /// <param name="password">������ ������������ ��� ����� � �������</param>
            /// <exception cref="ArgumentException">������ � ������, ���� ������������ ��� ����������</exception>
            public void AddUser(string login, string password)
            {
                User newUser = new User(login, password);
                users.Add(newUser);
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

            /// <summary>
            /// ����� ��� ������������� ������ �������������
            /// </summary>
            /// <returns>������ �������������</returns>
            public List<User> GetUsers()
            {
                return users;
            }
        }
    }
}