using Humanizer;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using TravelVoucher.Tools;
using WpfApp1.Tools;
using Color = System.Windows.Media.Color;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for HolidayPage.xaml
    /// </summary>
    public partial class HolidayPage : Page
    {
        public partial class Rating : UserControl
        {
            public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Rating", typeof(int), typeof(Rating),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RatingChanged)));

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
                    {
                        button.IsChecked = true;
                    }
                }

                for (int i = newval; i < childs.Count; i++)
                {
                    button = childs[i] as ToggleButton;
                    if (button != null)
                    {
                        button.IsChecked = false;
                    }
                }

            }

        }

        public HolidayPage()
        {
            InitializeComponent();
            string workingDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            string fileName = workingDirectory + @"txt-cities-russia.txt";
            string file = workingDirectory + @"vehicleType.txt";
            string foodFile = workingDirectory + @"food.txt";

            cBoxFrom.ItemsSource = File.ReadAllLines(fileName);
            cBoxTo.ItemsSource = File.ReadAllLines(fileName);
            cBoxTransport.ItemsSource = File.ReadAllLines(file);
            cBoxFood.ItemsSource = File.ReadAllLines(foodFile);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 4;
        }

        private void btnBuyTicket_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных из элементов управления
            string selectedCity = cBoxTo.SelectedItem.ToString();
            DateTime selectedDate = datePickerHoliday.SelectedDate ?? DateTime.Now;
            string vehicleType = cBoxTransport.SelectedItem.ToString();

            string name = GetHolidayName(selectedCity);
            double calculatedPrice = CalculatePrice(vehicleType);

            HolidayItem newItem = new HolidayItem
            {
                Name = name,
                Date = selectedDate,
                Price = calculatedPrice,
                Vehicle = vehicleType
            };

            lViewFoundHoldays.Items.Add(newItem);
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
        private double CalculatePrice(string type)
        {
            double price = 0.00;

            if (type != null)
            {
                string selectedVehicleType = type.ToString();

                switch (selectedVehicleType)
                {
                    case "Машина (своя)":
                        price = 1800.00 * Convert.ToDouble(upDownNumberOfGuests.Text);
                        break;

                    case "Машина (аренда)":
                        price = 2400.00 * Convert.ToDouble(upDownNumberOfGuests.Text);
                        break;

                    case "Автобус":
                        price = 3000.00 * Convert.ToDouble(upDownNumberOfGuests.Text);
                        break;

                    case "Поезд":
                        price = 3400.00 * Convert.ToDouble(upDownNumberOfGuests.Text);
                        break;

                    case "Самолёт":
                        price = 2000.00 * Convert.ToDouble(upDownNumberOfGuests.Text);
                        break;

                    case "Активные средства самостоятельного передвижения":
                        price = 800.00 * Convert.ToDouble(upDownNumberOfGuests.Text);
                        break;
                }
            }

            return price;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedCity">Выбранный элемент в combobox</param>
        /// <returns></returns>
        private string GetHolidayName(string selectedCity)
        {
            string excursionName = "Отдых в " + selectedCity.Humanize(LetterCasing.Title);
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