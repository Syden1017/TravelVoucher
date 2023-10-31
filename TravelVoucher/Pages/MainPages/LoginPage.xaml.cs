using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using TravelVoucher.Tools;
using WpfApp1.Tools;
using TravelVoucher.Pages.MainPages;
using static UserWork.Users;

namespace TravelVoucher.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private UserDataBase userDataBase;

        public LoginPage()
        {
            InitializeComponent();

            userDataBase = new UserDataBase();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 0;
        }

        private void txtBoxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxLogin.Text == "")
            {
                txtBoxLogin.Background = Brushes.LightCoral;
                txtBoxLogin.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(txtBoxLogin, 255, 242, 242);
                ColoredControl.SetBorderColor(txtBoxLogin, 0, 0, 0);
            }
        }

        private void passBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passBox.Password == "")
            {
                passBox.Background = Brushes.LightCoral;
                passBox.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(passBox, 255, 242, 242);
                ColoredControl.SetBorderColor(passBox, 0, 0, 0);
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtBoxLogin.Text;
            string password = passBox.Password;

            if (txtBoxLogin.Text.Length > 0
                && passBox.Password.Length > 0)
            {
                if (userDataBase.CheckUser(login, password))
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

                    registrationLabel.Visibility = Visibility.Visible;

                    if (!userDataBase.CheckLogin(login))
                    {
                        txtBoxLogin.Background = Brushes.LightCoral;
                        txtBoxLogin.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        ColoredControl.SetBackgroundColor(txtBoxLogin, 255, 242, 242);
                        ColoredControl.SetBorderColor(txtBoxLogin, 0, 0, 0);
                    }

                    if (!userDataBase.CheckPassword(password))
                    {
                        passBox.Background = Brushes.LightCoral;
                        passBox.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        ColoredControl.SetBackgroundColor(passBox, 255, 242, 242);
                        ColoredControl.SetBorderColor(passBox, 0, 0, 0);
                    }
                }
            }
            else
            {
                if (txtBoxLogin.Text == ""
                    && passBox.Password == "")
                {
                    MessageBox.Show(
                        "Введите логин и пароль!",
                        "Ошибка авторизации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                        );

                    txtBoxLogin.Background = Brushes.LightCoral;
                    txtBoxLogin.BorderBrush = Brushes.Red;

                    passBox.Background = Brushes.LightCoral;
                    passBox.BorderBrush = Brushes.Red;
                }
                else if (txtBoxLogin.Text.Length > 0
                         && passBox.Password == "")
                {
                    if (!userDataBase.CheckLogin(login))
                    {
                        MessageBox.Show(
                            "Введите пароль и корректное имя пользователя!",
                            "Ошибка авторизации",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                            );

                        txtBoxLogin.Background = Brushes.LightCoral;
                        txtBoxLogin.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        ColoredControl.SetBackgroundColor(txtBoxLogin, 255, 242, 242);
                        ColoredControl.SetBorderColor(txtBoxLogin, 0, 0, 0);

                        MessageBox.Show(
                            "Введите пароль!",
                            "Ошибка авторизации",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                            );
                    }

                    passBox.Background = Brushes.LightCoral;
                    passBox.BorderBrush = Brushes.Red;
                }
                else if (txtBoxLogin.Text == ""
                         && passBox.Password.Length > 0)
                {
                    txtBoxLogin.Background = Brushes.LightCoral;
                    txtBoxLogin.BorderBrush = Brushes.Red;

                    if (!userDataBase.CheckPassword(password))
                    {
                        MessageBox.Show(
                            "Введите логин и корректный пароль!",
                            "Ошибка авторизации",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                            );

                        passBox.Background = Brushes.LightCoral;
                        passBox.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        ColoredControl.SetBackgroundColor(passBox, 255, 242, 242);
                        ColoredControl.SetBorderColor(passBox, 0, 0, 0);

                        MessageBox.Show(
                            "Введите логин!",
                            "Ошибка авторизации",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                            );
                    }
                }
            }
        }

        private void btnShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (passBox.PasswordChar == '●')
            {
                passBox.PasswordChar = '\0';
                btnShowPassword.Content = "C:\\Users\\User\\source\\repos\\Новая папка\\TravelVoucher\\Images\\ControlImages\\closeEye.png";
            }
            else
            {
                passBox.PasswordChar = '●';
                btnShowPassword.Content = "C:\\Users\\User\\source\\repos\\Новая папка\\TravelVoucher\\Images\\ControlImages\\openEye.png";
            }
        }

        private void registrationLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Navigation.frmObj.Navigate(new RegistrationPage());
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passBox.Password.Length > 0)
            {
                Watermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermark.Visibility = Visibility.Visible;
            }
        }
    }
}