using System.Windows;
using System.Windows.Input;
using System.ComponentModel;

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

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show(
                           "Действительно хотите отменить транзакцию?",
                           "Отмена транзакции",
                           MessageBoxButton.YesNo,
                           MessageBoxImage.Question,
                           MessageBoxResult.Yes) == MessageBoxResult.No;
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
            this.Close();
            MessageBox.Show(
                "Транзакция отменена",
                "Отмена транзакции",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }

        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Транзакция прошла успешно",
                "Выполнения пополнения",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );

            Close();
        }
    }
}