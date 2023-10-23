using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
            Color colorWhite = Color.FromRgb(255, 242, 242);
            Brush brushWhite = new SolidColorBrush(colorWhite);

            Color colorBlack = Color.FromRgb(0, 0, 0);
            Brush brushBlack = new SolidColorBrush(colorBlack);

            if (txtBoxCardNumber.Text.Length > 0
                && txtBoxMonth.Text.Length > 0
                && txtBoxYear.Text.Length > 0
                && txtBoxCodeCVC.Text.Length > 0
                && txtBoxReplenishmentAmount.Text.Length > 0)
            {
                MessageBox.Show(
                    "Транзакция прошла успешно",
                    "Выполнения пополнения",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );

                this.Close();
                
            }
            else
            {
                if (txtBoxCardNumber.Text == ""
                    && txtBoxMonth.Text == ""
                    && txtBoxYear.Text == ""
                    && txtBoxCodeCVC.Text == ""
                    && txtBoxReplenishmentAmount.Text == "")
                {
                    MessageBox.Show(
                        "Введите номер, срок действия, " +
                        "код на обратной стороне карты " +
                        "и сумму пополнения",
                        "Ошибка пополнения",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );

                    txtBoxCardNumber.Background = Brushes.LightCoral;
                    txtBoxCardNumber.BorderBrush = Brushes.Red;

                    txtBoxMonth.Background = Brushes.LightCoral;
                    txtBoxMonth.BorderBrush = Brushes.Red;

                    txtBoxYear.Background = Brushes.LightCoral;
                    txtBoxYear.BorderBrush = Brushes.Red;

                    txtBoxCodeCVC.Background = Brushes.LightCoral;
                    txtBoxCodeCVC.BorderBrush = Brushes.Red;

                    txtBoxReplenishmentAmount.Background = Brushes.LightCoral;
                    txtBoxReplenishmentAmount.BorderBrush = Brushes.Red;
                }
                else if (txtBoxCardNumber.Text.Length > 0
                         && txtBoxMonth.Text == ""
                         && txtBoxYear.Text == ""
                         && txtBoxCodeCVC.Text == ""
                         && txtBoxReplenishmentAmount.Text == "")
                {
                    MessageBox.Show(
                        "Введите срок действия, " +
                        "код на обратной стороне карты " +
                        "и сумму пополнения",
                        "Ошибка пополнения",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );

                    txtBoxCardNumber.Background = brushWhite;
                    txtBoxCardNumber.BorderBrush = brushBlack;

                    txtBoxMonth.Background = Brushes.LightCoral;
                    txtBoxMonth.BorderBrush = Brushes.Red;

                    txtBoxYear.Background = Brushes.LightCoral;
                    txtBoxYear.BorderBrush = Brushes.Red;

                    txtBoxCodeCVC.Background = Brushes.LightCoral;
                    txtBoxCodeCVC.BorderBrush = Brushes.Red;

                    txtBoxReplenishmentAmount.Background = Brushes.LightCoral;
                    txtBoxReplenishmentAmount.BorderBrush = Brushes.Red;
                }
                else if (txtBoxCardNumber.Text.Length > 0
                         && txtBoxMonth.Text.Length > 0
                         && txtBoxYear.Text.Length > 0
                         && txtBoxCodeCVC.Text == ""
                         && txtBoxReplenishmentAmount.Text == "")
                {
                    MessageBox.Show(
                        "Введите код на обратной стороне карты " +
                        "и сумму пополнения",
                        "Ошибка пополнения",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );

                    txtBoxCardNumber.Background = brushWhite;
                    txtBoxCardNumber.BorderBrush = brushBlack;

                    txtBoxMonth.Background = brushWhite;
                    txtBoxMonth.BorderBrush = brushBlack;

                    txtBoxYear.Background = brushWhite;
                    txtBoxYear.BorderBrush = brushBlack;

                    txtBoxCodeCVC.Background = Brushes.LightCoral;
                    txtBoxCodeCVC.BorderBrush = Brushes.Red;

                    txtBoxReplenishmentAmount.Background = Brushes.LightCoral;
                    txtBoxReplenishmentAmount.BorderBrush = Brushes.Red;
                }
                else if (txtBoxCardNumber.Text.Length > 0
                         && txtBoxMonth.Text.Length > 0
                         && txtBoxYear.Text.Length > 0
                         && txtBoxCodeCVC.Text .Length > 0
                         && txtBoxReplenishmentAmount.Text == "")
                {
                    MessageBox.Show(
                        "Введите сумму пополнения",
                        "Ошибка пополнения",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );

                    txtBoxCardNumber.Background = brushWhite;
                    txtBoxCardNumber.BorderBrush = brushBlack;

                    txtBoxMonth.Background = brushWhite;
                    txtBoxMonth.BorderBrush = brushBlack;

                    txtBoxYear.Background = brushWhite;
                    txtBoxYear.BorderBrush = brushBlack;

                    txtBoxCodeCVC.Background = brushWhite;
                    txtBoxCodeCVC.BorderBrush = brushBlack;

                    txtBoxReplenishmentAmount.Background = Brushes.LightCoral;
                    txtBoxReplenishmentAmount.BorderBrush = Brushes.Red;
                }
            }
        }
    }
}