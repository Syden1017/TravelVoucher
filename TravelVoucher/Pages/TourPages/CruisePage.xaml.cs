using Humanizer;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using TravelVoucher.Tools;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for CruisePage.xaml
    /// </summary>
    public partial class CruisePage : Page
    {
        public partial class Rating : UserControl
        {
            public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Rating", typeof(int), typeof(Rating),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RatingChanged)));

            private int _max = 5;

            public int Value
            {
                get
                {
                    return (int)GetValue(ValueProperty);
                }
                set
                {
                    if (value < 0)
                    {
                        SetValue(ValueProperty, 0);
                    }
                    else if (value > _max)
                    {
                        SetValue(ValueProperty, _max);
                    }
                    else
                    {
                        SetValue(ValueProperty, value);
                    }
                }
            }

            private static void RatingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                Rating item = sender as Rating;
                int newval = (int)e.NewValue;
                UIElementCollection childs = ((Grid)(item.Content)).Children;

                ToggleButton button = null;

                for (int i = 0; i < newval; i++)
                {
                    button = childs[i] as ToggleButton;
                    if (button != null)
                        button.IsChecked = true;
                }

                for (int i = newval; i < childs.Count; i++)
                {
                    button = childs[i] as ToggleButton;
                    if (button != null)
                        button.IsChecked = false;
                }

            }

        }
        public CruisePage()
        {
            InitializeComponent();
            string workingDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            string fileName = workingDirectory + @"txt-cities-russia.txt";

            cBoxFrom.ItemsSource = File.ReadAllLines(fileName);
            cBoxRoute.ItemsSource = File.ReadAllLines(fileName);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 8;
        }

        private void btnBuyTicket_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных из элементов управления
            string selectedCity = cBoxRoute.SelectedItem.ToString();
            DateTime selectedDate = datePickerCriuse.SelectedDate ?? DateTime.Now;

            string name = GetCruiseName(selectedCity);
            double calculatedPrice = CalculatePrice();

            HolidayItem newItem = new HolidayItem
            {
                Name = name,
                Date = selectedDate,
                Price = calculatedPrice
            };

            lViewFoundCruise.Items.Add(newItem);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }

        #region Методы
        /// <summary>
        /// Расчёт суммы в зависимости от типа экскурсии
        /// </summary>
        /// <returns>Подсчитанная стоимость поездки</returns>
        private double CalculatePrice()
        {
            double price = 1200.00 * Convert.ToDouble(txtBoxCruiseDays.Text) * Convert.ToDouble(txtBoxNumberOfPeoples.Text);

            return price;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedCity">Выбранный элемент в combobox</param>
        /// <returns></returns>
        private string GetCruiseName(string selectedCity)
        {
            string excursionName = "Круиз до " + selectedCity.Humanize(LetterCasing.Title);
            return excursionName;
        }
        #endregion

        #region ToogleButton (для звёзд)
        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            int Value = newvalue;
        }

        private void ToggleButton_Click_1(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            int Value = newvalue;
        }

        private void ToggleButton_Click_2(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            int Value = newvalue;
        }

        private void ToggleButton_Click_3(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            int Value = newvalue;
        }

        private void ToggleButton_Click_4(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            int Value = newvalue;
        }
        #endregion
    }
}