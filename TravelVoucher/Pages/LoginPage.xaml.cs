using System.Windows;
using System.Windows.Controls;
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
            if (txtBoxLogin.Text == "Пользователь" && passBox.Password == "12345" ||
                txtBoxLogin.Text == "Админ" && passBox.Password == "qwerty" ||
                txtBoxLogin.Text == "User" && passBox.Password == "12345" ||
                txtBoxLogin.Text == "Admin" && passBox.Password == "qwerty")
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