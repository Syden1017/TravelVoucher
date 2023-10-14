using System.Windows;
using WpfApp1.Tools;

namespace TravelVoucher.Windows
{
    /// <summary>
    /// Interaction logic for TopUpBalance.xaml
    /// </summary>
    public partial class TopUpBalance : Window
    {
        public TopUpBalance()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 12;
        }
    }
}