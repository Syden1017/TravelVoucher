using System.Windows;
using System.Windows.Controls;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for SanatoriumPage.xaml
    /// </summary>
    public partial class SanatoriumPage : Page
    {
        public SanatoriumPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 6;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }

        private void btnBuyTicket_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
