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
            private List<User> users;

            public UserDataBase()
            {
                string filePath = "\\Data\\users.txt";
                users = new List<User>();
                InitializeUsers(filePath);
            }

            /// <summary>
            /// ���������� ������ ������������
            /// </summary>
            /// <param name="login">��� ������������ ��� ����� � �������</param>
            /// <param name="password">������ ������������ ��� ����� � �������</param>
            public void AddUser(string login, string password)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter("users.txt", true))
                    {
                        writer.WriteLine(login, password);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(
                        "������ ������ ������������ � ����: " + 
                        ex.Message,
                        "������ ����������",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                        );
                }
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

            public List<User> InitializeUsers(string filePath)
            {
                List<User> users = new List<User>();

                if (File.Exists(filePath))
                {
                    string[] strings = File.ReadAllLines(filePath);

                    foreach (string s in strings)
                    {
                        string[] parts = s.Split(',');

                        if (parts.Length > 2)
                        {
                            User user = new User(login: parts[0], password: parts[1]);
                            users.Add(user);
                        }
                    }
                }
                return users;
            }
        }
    }
}
