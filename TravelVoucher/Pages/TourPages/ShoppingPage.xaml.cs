using System.Windows;
using System.Windows.Controls;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for ShoppingPage.xaml
    /// </summary>
    public partial class ShoppingPage : Page
    {
        public ShoppingPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 7;
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
