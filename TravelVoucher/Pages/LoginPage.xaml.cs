﻿using System.Windows;
using System.Windows.Controls;
using TravelVoucher.Tools;
using WpfApp1.Tools;

namespace TravelVoucher.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 0;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxLogin.Text == "User" && passBox.Password == "12345")
            {
                Navigation.frmObj.Navigate(new HomePage());
            }
            else
            {
                MessageBox.Show(
                    "Неправильный логин или пароль",
                    "Ошибка авторизации",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
            }
        }
    }
}