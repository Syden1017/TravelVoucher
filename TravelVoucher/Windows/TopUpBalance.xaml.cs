using System;
using System.Windows;
using System.Windows.Input;
using TravelVoucher.Pages;

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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        }

        private void btnTransaction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(
                    "Транзакция прошла успешно",
                    "Выполнение пополнения",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message.ToString(),
                    "Системная ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
            }
        }
    }
}