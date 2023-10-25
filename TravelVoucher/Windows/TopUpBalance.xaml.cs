using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TravelVoucher.Tools;
using System.Windows.Controls;
using System.Linq;

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

        #region События текстового поля номера карты
        private void txtBoxCardNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxCardNumber.Text == "")
            {
                txtBoxCardNumber.Background = Brushes.LightCoral;
                txtBoxCardNumber.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(txtBoxCardNumber, 255, 242, 242);
                ColoredControl.SetBorderColor(txtBoxCardNumber, 0, 0, 0);
            }
        }

        private void txtBoxCardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string cardNumber = txtBoxCardNumber.Text.Replace(" ", "");

            if (cardNumber.Length > 0)
            {
                string formattedCardNumber = string.Join(" ", Enumerable.Range
                    (0, (int)Math.Ceiling((double)cardNumber.Length / 4))
                    .Select(i => cardNumber.Substring(i * 4, Math.Min(4, cardNumber.Length - i * 4))));
                txtBoxCardNumber.Text = formattedCardNumber;
                txtBoxCardNumber.CaretIndex = formattedCardNumber.Length;
            }
        }

        private void txtBoxCardNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = txtBoxCardNumber;

            if (textBox.Text.Length >= 19)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region События текстового поля срока действия карты
        private void txtBoxMonth_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxMonth.Text == "")
            {
                txtBoxMonth.Background = Brushes.LightCoral;
                txtBoxMonth.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(txtBoxMonth, 255, 242, 242);
                ColoredControl.SetBorderColor(txtBoxMonth, 0, 0, 0);
            }
        }

        private void txtBoxMonth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = txtBoxMonth;

            if (textBox.Text.Length >= 2)
            {
                e.Handled = true;
            }
        }

        private void txtBoxYear_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxYear.Text == "")
            {
                txtBoxYear.Background = Brushes.LightCoral;
                txtBoxYear.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(txtBoxYear, 255, 242, 242);
                ColoredControl.SetBorderColor(txtBoxYear, 0, 0, 0);
            }
        }

        private void txtBoxYear_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = txtBoxYear;

            if (textBox.Text.Length >= 2)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region События текстового поля кода на обратной стороне карты
        private void txtBoxCodeCVC_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxCodeCVC.Text == "")
            {
                txtBoxCodeCVC.Background = Brushes.LightCoral;
                txtBoxCodeCVC.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(txtBoxCodeCVC, 255, 242, 242);
                ColoredControl.SetBorderColor(txtBoxCodeCVC, 0, 0, 0);
            }
        }

        private void txtBoxCodeCVC_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = txtBoxCodeCVC;

            if (textBox.Text.Length >= 3)
            {
                e.Handled = true;
            }
        }
        #endregion

        private void txtBoxReplenishmentAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxReplenishmentAmount.Text == "")
            {
                txtBoxReplenishmentAmount.Background = Brushes.LightCoral;
                txtBoxReplenishmentAmount.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(txtBoxReplenishmentAmount, 255, 242, 242);
                ColoredControl.SetBorderColor(txtBoxReplenishmentAmount, 0, 0, 0);
            }
        }

        #region Обработчики событий при нажатии на кнопку
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
            int cardNumber,
                month,
                year,
                cvcCode,
                replenishmentAmount;

            if (txtBoxCardNumber.Text.Length > 0
                && txtBoxMonth.Text.Length > 0
                && txtBoxYear.Text.Length > 0
                && txtBoxCodeCVC.Text.Length > 0
                && txtBoxReplenishmentAmount.Text.Length > 0)
            {
                if (Int32.TryParse(txtBoxCardNumber.Text, out cardNumber)
                    && Int32.TryParse(txtBoxMonth.Text, out month)
                    && Int32.TryParse(txtBoxYear.Text, out year)
                    && Int32.TryParse(txtBoxCodeCVC.Text, out cvcCode)
                    && Int32.TryParse(txtBoxReplenishmentAmount.Text, out replenishmentAmount))
                {
                    MessageBox.Show(
                        "Транзакция прошла успешно",
                        "Выполнение транзакции",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                        );

                    this.Close();
                }
                else
                {
                    if (!Int32.TryParse(txtBoxCardNumber.Text, out cardNumber)
                        && Int32.TryParse(txtBoxMonth.Text, out month)
                        && Int32.TryParse(txtBoxYear.Text, out year)
                        && Int32.TryParse(txtBoxCodeCVC.Text, out cvcCode)
                        && Int32.TryParse(txtBoxReplenishmentAmount.Text, out replenishmentAmount))
                    {
                        MessageBox.Show(
                            "Введите корректный номер карты",
                            "Ошибка пополнения",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                            );

                        txtBoxCardNumber.Background = Brushes.LightCoral;
                        txtBoxCardNumber.BorderBrush = Brushes.Red;

                        ColoredControl.SetBackgroundColor(txtBoxMonth, 255, 242, 242);
                        ColoredControl.SetBorderColor(txtBoxMonth, 0, 0, 0);

                        ColoredControl.SetBackgroundColor(txtBoxYear, 255, 242, 242);
                        ColoredControl.SetBorderColor(txtBoxYear, 0, 0, 0);

                        ColoredControl.SetBackgroundColor(txtBoxCodeCVC, 255, 242, 242);
                        ColoredControl.SetBorderColor(txtBoxCodeCVC, 0, 0, 0);

                        ColoredControl.SetBackgroundColor(txtBoxReplenishmentAmount, 255, 242, 242);
                        ColoredControl.SetBorderColor(txtBoxReplenishmentAmount, 0, 0, 0);

                        txtBoxCardNumber.Clear();
                    }
                    else if (!Int32.TryParse(txtBoxCardNumber.Text, out cardNumber)
                             && !Int32.TryParse(txtBoxMonth.Text, out month)
                             && !Int32.TryParse(txtBoxYear.Text, out year)
                             && Int32.TryParse(txtBoxCodeCVC.Text, out cvcCode)
                             && Int32.TryParse(txtBoxReplenishmentAmount.Text, out replenishmentAmount))
                    {
                        MessageBox.Show(
                            "Введите корректный номер карты и срок действия",
                            "Ошибка пополнения",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                            );

                        txtBoxCardNumber.Background = Brushes.LightCoral;
                        txtBoxCardNumber.BorderBrush = Brushes.Red;

                        txtBoxMonth.Background = Brushes.LightCoral;
                        txtBoxMonth.BorderBrush = Brushes.Red;

                        txtBoxYear.Background = Brushes.LightCoral;
                        txtBoxYear.BorderBrush = Brushes.Red;

                        ColoredControl.SetBackgroundColor(txtBoxCodeCVC, 255, 242, 242);
                        ColoredControl.SetBorderColor(txtBoxCodeCVC, 0, 0, 0);

                        ColoredControl.SetBackgroundColor(txtBoxReplenishmentAmount, 255, 242, 242);
                        ColoredControl.SetBorderColor(txtBoxReplenishmentAmount, 0, 0, 0);

                        txtBoxCardNumber.Clear();
                        txtBoxMonth.Clear();
                        txtBoxYear.Clear();
                    }
                    else if (!Int32.TryParse(txtBoxCardNumber.Text, out cardNumber)
                             && !Int32.TryParse(txtBoxMonth.Text, out month)
                             && !Int32.TryParse(txtBoxYear.Text, out year)
                             && !Int32.TryParse(txtBoxCodeCVC.Text, out cvcCode)
                             && Int32.TryParse(txtBoxReplenishmentAmount.Text, out replenishmentAmount))
                    {
                        MessageBox.Show(
                            "Введите корректный номер карты, срок действия" +
                            "и код на обратной стороне карты",
                            "Ошибка пополнения",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                            );

                        txtBoxCardNumber.Background = Brushes.LightCoral;
                        txtBoxCardNumber.BorderBrush = Brushes.Red;

                        txtBoxMonth.Background = Brushes.LightCoral;
                        txtBoxMonth.BorderBrush = Brushes.Red;

                        txtBoxYear.Background = Brushes.LightCoral;
                        txtBoxYear.BorderBrush = Brushes.Red;

                        txtBoxCodeCVC.Background = Brushes.LightCoral;
                        txtBoxCodeCVC.BorderBrush = Brushes.Red;

                        ColoredControl.SetBackgroundColor(txtBoxReplenishmentAmount, 255, 242, 242);
                        ColoredControl.SetBorderColor(txtBoxReplenishmentAmount, 0, 0, 0);

                        txtBoxCardNumber.Clear();
                        txtBoxMonth.Clear();
                        txtBoxYear.Clear();
                        txtBoxCodeCVC.Clear();
                    }
                    else if (!Int32.TryParse(txtBoxCardNumber.Text, out cardNumber)
                             && !Int32.TryParse(txtBoxMonth.Text, out month)
                             && !Int32.TryParse(txtBoxYear.Text, out year)
                             && !Int32.TryParse(txtBoxCodeCVC.Text, out cvcCode)
                             && !Int32.TryParse(txtBoxReplenishmentAmount.Text, out replenishmentAmount))
                    {
                        MessageBox.Show(
                            "Введите корректные номер карты, срок действия, " +
                            "код на обратной стороне карты и сумму пополнения",
                            "Ошибка пополнения",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
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

                        txtBoxCardNumber.Clear();
                        txtBoxMonth.Clear();
                        txtBoxYear.Clear();
                        txtBoxCodeCVC.Clear();
                        txtBoxReplenishmentAmount.Clear();
                    }
                }
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

                    ColoredControl.SetBackgroundColor(txtBoxCardNumber, 255, 242, 242);
                    ColoredControl.SetBorderColor(txtBoxCardNumber, 0, 0, 0);

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

                    ColoredControl.SetBackgroundColor(txtBoxCardNumber, 255, 242, 242);
                    ColoredControl.SetBorderColor(txtBoxCardNumber, 0, 0, 0);

                    ColoredControl.SetBackgroundColor(txtBoxMonth, 255, 242, 242);
                    ColoredControl.SetBorderColor(txtBoxMonth, 0, 0, 0);

                    ColoredControl.SetBackgroundColor(txtBoxYear, 255, 242, 242);
                    ColoredControl.SetBorderColor(txtBoxYear, 0, 0, 0);

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

                    ColoredControl.SetBackgroundColor(txtBoxCardNumber, 255, 242, 242);
                    ColoredControl.SetBorderColor(txtBoxCardNumber, 0, 0, 0);

                    ColoredControl.SetBackgroundColor(txtBoxMonth, 255, 242, 242);
                    ColoredControl.SetBorderColor(txtBoxMonth, 0, 0, 0);

                    ColoredControl.SetBackgroundColor(txtBoxYear, 255, 242, 242);
                    ColoredControl.SetBorderColor(txtBoxYear, 0, 0, 0);

                    ColoredControl.SetBackgroundColor(txtBoxCodeCVC, 255, 242, 242);
                    ColoredControl.SetBorderColor(txtBoxCodeCVC, 0, 0, 0);

                    txtBoxReplenishmentAmount.Background = Brushes.LightCoral;
                    txtBoxReplenishmentAmount.BorderBrush = Brushes.Red;
                }
            }
        }
        #endregion
    }
}