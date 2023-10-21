using System.Windows;
using System.Windows.Input;

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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnCancelTransaction_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Транзакция отменена",
                "Отмена транзакции",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
            
            this.Close();
        }

        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Транзакция прошла успешно",
                "Выполнения пополнения",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
            
            this.Close();
        }
    }
}