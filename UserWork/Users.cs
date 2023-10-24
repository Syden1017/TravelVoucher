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
            /// ���������� ������ ������������
            /// </summary>
            /// <param name="username">��� ������������ ��� ����� � �������</param>
            /// <param name="password">������ ������������ ��� ����� � �������</param>
            /// <exception cref="ArgumentException">������ � ������, ���� ������������ ��� ����������</exception>
            public void AddUser(string username, string password)
            {
                // ��������� ���� �� ������������ � ������
                if (UserExists(username))
                {
                    throw new ArgumentException("������������ ��� ����������.");
                }

                users.Add(new User { Login = username, Password = password });
            }

            /// <summary>
            /// �������� �� ������� ������������ � �������
            /// </summary>
            /// <param name="username">��� ������������ ��� ����� � �������</param>
            /// <returns>������ ��� ����</returns>
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
        }
    }
}