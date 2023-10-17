using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

        private void txtBoxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxLogin.Text == "")
            {
                txtBoxLogin.Background = Brushes.LightCoral;
                txtBoxLogin.BorderBrush = Brushes.Red;
            }
            else
            {
                Color colorWhite = Color.FromRgb(255, 242, 242);
                Brush brushWhite = new SolidColorBrush(colorWhite);

                Color colorBlack = Color.FromRgb(0, 0, 0);
                Brush brushBlack = new SolidColorBrush(colorBlack);

                txtBoxLogin.Background = brushWhite;
                txtBoxLogin.BorderBrush = brushBlack;
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
                Color colorWhite = Color.FromRgb(255, 242, 242);
                Brush brushWhite = new SolidColorBrush(colorWhite);

                Color colorBlack = Color.FromRgb(0, 0, 0);
                Brush brushBlack = new SolidColorBrush(colorBlack);

                passBox.Background = brushWhite;
                passBox.BorderBrush = brushBlack;
            }
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Color colorWhite = Color.FromRgb(255, 242, 242);
            Brush brushWhite = new SolidColorBrush(colorWhite);

            Color colorBlack = Color.FromRgb(0, 0, 0);
            Brush brushBlack = new SolidColorBrush(colorBlack);

            if (txtBoxLogin.Text.Length > 0)
            {
                if (passBox.Password.Length > 0)
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

                        if (txtBoxLogin.Text != "User")
                        {
                            txtBoxLogin.Background = Brushes.LightCoral;
                            txtBoxLogin.BorderBrush = Brushes.Red;
                        }
                        else
                        {
                            txtBoxLogin.Background = brushWhite;
                            txtBoxLogin.BorderBrush = brushBlack;
                        }

                        if (passBox.Password != "12345")
                        {
                            passBox.Background = Brushes.LightCoral;
                            passBox.BorderBrush = Brushes.Red;
                        }
                        else
                        {
                            passBox.Background = brushWhite;
                            passBox.BorderBrush = brushBlack;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Введите пароль!",
                        "Ошибка авторизации",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                        );

                    passBox.Background = Brushes.LightCoral;
                    passBox.BorderBrush = Brushes.Red;
                }
            }
            else
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
        }
    }
}