using System.Windows;
using System.Windows.Controls;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.PopUpMenuPages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 11;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }

        private void btnAccountExit_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new LoginPage());
        }
    }
}