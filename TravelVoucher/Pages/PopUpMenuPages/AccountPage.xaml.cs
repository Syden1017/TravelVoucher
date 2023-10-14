using System.Windows;
using System.Windows.Controls;
using WpfApp1.Tools;
using TravelVoucher.Windows;

namespace TravelVoucher.Pages.PopUpMenuPages
{
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 10;
        }

        private void btnTopUpBalance_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new TopUpBalance());
        }

        private void btnAccountExit_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new LoginPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }
    }
}