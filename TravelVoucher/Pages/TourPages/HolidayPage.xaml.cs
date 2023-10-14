using System.Windows;
using System.Windows.Controls;
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

        private void btnBuyTicket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }
    }
}