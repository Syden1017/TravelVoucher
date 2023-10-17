using System.Windows;
using System.Windows.Controls;
using TravelVoucher.Pages.PopUpMenuPages;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for ExcursionPage.xaml
    /// </summary>
    public partial class ExcursionPage : Page
    {
        public ExcursionPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 5;
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