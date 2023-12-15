using Humanizer;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TravelVoucher.Tools;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.TourPages
{

    /// <summary>
    /// Interaction logic for ExcursionPage.xaml
    /// </summary>
    public partial class ExcursionPage : Page
    {
        public ExcursionPage()
        {
            InitializeComponent();
            string workingDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            string fileName = workingDirectory + @"txt-cities-russia.txt";
            string file = workingDirectory + @"excursionTypes.txt";

            cBoxFrom.ItemsSource = File.ReadAllLines(fileName);
            cBoxTo.ItemsSource = File.ReadAllLines(fileName);
            cBoxExcursionType.ItemsSource = File.ReadAllLines(file);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 5;
        }

        private void btnFindTickets_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных из элементов управления
            string selectedCity = cBoxTo.SelectedItem.ToString();
            DateTime selectedDate = datePickerExcursion.SelectedDate ?? DateTime.Now;
            string excursionType = cBoxExcursionType.SelectedItem.ToString();

            string name = GetExcursionName(selectedCity);
            double calculatedPrice = CalculatePrice(excursionType);

            ExcursionItem newItem = new ExcursionItem
            {
                Name = name,
                Date = selectedDate,
                Price = calculatedPrice
            };

            lViewFoundExcursions.Items.Add(newItem);
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
                string selectedExcursionType = type.ToString();

                switch(selectedExcursionType) 
                {
                    case "обзорная":
                        price = 1800.00 * Convert.ToInt32(upDownTourist.Text);
                        break;

                    case "историческая":
                        price = 2400.00 * Convert.ToInt32(upDownTourist.Text);
                        break;

                    case "городская":
                        price = 3000.00 * Convert.ToInt32(upDownTourist.Text);
                        break;
                    
                    case "загородная":
                        price = 3400.00 * Convert.ToInt32(upDownTourist.Text);
                        break;

                    case "музейная":
                        price = 2000.00 * Convert.ToInt32(upDownTourist.Text);
                        break;

                    case "учебная":
                        price = 800.00 * Convert.ToInt32(upDownTourist.Text);
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
        private string GetExcursionName(string selectedCity)
        {
            string excursionName = "Экскурсия по " + selectedCity.Humanize(LetterCasing.Title);
            return excursionName;
        }
        #endregion
    }
}