using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TravelVoucher.Tools;
using WpfApp1.Tools;
using static UserWork.Users;

namespace TravelVoucher.Pages.MainPages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private UserDataBase userDataBase;

        public RegistrationPage()
        {
            InitializeComponent();

            userDataBase = new UserDataBase();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 12;
        }

        private void txtBoxRegistrationLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxRegistrationLogin.Text == "")
            {
                txtBoxRegistrationLogin.Background = Brushes.LightCoral;
                txtBoxRegistrationLogin.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(txtBoxRegistrationLogin, 255, 242, 242);
                ColoredControl.SetBorderColor(txtBoxRegistrationLogin, 0, 0, 0);
            }
        }

        private void passBoxRegistration_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passBoxRegistration.Password == "")
            {
                passBoxRegistration.Background = Brushes.LightCoral;
                passBoxRegistration.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(passBoxRegistration, 255, 242, 242);
                ColoredControl.SetBorderColor(passBoxRegistration, 0, 0, 0);

                passBoxRepeatPassword.Visibility = Visibility.Visible;
            }
        }

        private void btnCancelRegistration_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Регистрация отменена",
                "Отмена регистрации",
                MessageBoxButton.OK,
                MessageBoxImage.Warning
                );

            Navigation.frmObj.GoBack();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string login = txtBoxRegistrationLogin.Text;
            string password = passBoxRegistration.Password;

            if (!string.IsNullOrEmpty(login)
                && !string.IsNullOrEmpty(password))
            {
                if (passBoxRegistration.Password == passBoxRepeatPassword.Password)
                {
                    if (!userDataBase.CheckUser(login, password))
                    {
                        MessageBox.Show(
                            "Регистрация прошла успешно",
                            "Регистрация",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
                            );

                        userDataBase.AddUser(login, password);

                        Navigation.frmObj.Navigate(new LoginPage());
                    }
                    else
                    {
                        MessageBox.Show(
                            "Пользователь уже существует",
                            "Ошибка регистрация",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning
                            );

                        txtBoxRegistrationLogin.Background = Brushes.LightCoral;
                        txtBoxRegistrationLogin.BorderBrush = Brushes.Red;

                        passBoxRegistration.Background = Brushes.LightCoral;
                        passBoxRegistration.BorderBrush = Brushes.Red;

                        passBoxRepeatPassword.Background = Brushes.LightCoral;
                        passBoxRepeatPassword.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Пароли не совпадают. Попробуйте ещё раз.",
                        "Ошибка регистрации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );

                    passBoxRepeatPassword.Background = Brushes.LightCoral;
                    passBoxRepeatPassword.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(login)
                    && string.IsNullOrEmpty(password))
                {
                    MessageBox.Show(
                        "Введите логин и пароль!",
                        "Ошибка регистрации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                        );

                    txtBoxRegistrationLogin.Background = Brushes.LightCoral;
                    txtBoxRegistrationLogin.BorderBrush = Brushes.Red;

                    passBoxRegistration.Background = Brushes.LightCoral;
                    passBoxRegistration.BorderBrush = Brushes.Red;

                    passBoxRepeatPassword.Background = Brushes.LightCoral;
                    passBoxRepeatPassword.BorderBrush = Brushes.Red;
                }
                else if (!string.IsNullOrEmpty(login)
                         && string.IsNullOrEmpty(password))
                {
                    MessageBox.Show(
                        "Введите пароль!",
                        "Ошибка регистрации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                        );

                    ColoredControl.SetBackgroundColor(txtBoxRegistrationLogin, 255, 242, 242);
                    ColoredControl.SetBorderColor(txtBoxRegistrationLogin, 0, 0, 0);

                    passBoxRegistration.Background = Brushes.LightCoral;
                    passBoxRegistration.BorderBrush = Brushes.Red;
                }
                else if (string.IsNullOrEmpty(login)
                         && !string.IsNullOrEmpty(password))
                {
                    MessageBox.Show(
                        "Введите логин!",
                        "Ошибка регистрации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                        );

                    passBoxRepeatPassword.Visibility = Visibility.Visible;

                    txtBoxRegistrationLogin.Background = Brushes.LightCoral;
                    txtBoxRegistrationLogin.BorderBrush = Brushes.Red;

                    ColoredControl.SetBackgroundColor(passBoxRegistration, 255, 242, 242);
                    ColoredControl.SetBorderColor(passBoxRegistration, 0, 0, 0);
                }
            }
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (passBoxRegistration.Password.Length > 0)
            {
                Watermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermark.Visibility = Visibility.Visible;
            }

            if (passBoxRepeatPassword.Password.Length > 0)
            {
                repeatWatermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                repeatWatermark.Visibility = Visibility.Visible;
            }
        }
    }
}