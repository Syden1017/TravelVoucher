using System.Windows;
using System.Windows.Controls;
using TravelVoucher.Pages.PopUpMenuPages;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for HolidayPage.xaml
    /// </summary>
    public partial class HolidayPage : Page
    {
        public HolidayPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 4;
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new AccountPage());
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new SettingsPage());
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Остались вопросы?" +
                "\nВы можете задать их по номеру телефона: 89005063245",
                "Поддержка",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new LoginPage());
        }

        private void btnBuyTicket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }
    }
}