using Humanizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        string imagePath = "";

        private List<string> _pathImages;
        public List<string> ListImages { get; private set; }

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
            string img = GetImage(selectedCity);

            ExcursionItem newItem = new ExcursionItem
            {
                Name = name,
                Date = selectedDate,
                Price = calculatedPrice,
                CityImage = img
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

        private string GetImage(string city)
        {
            if (city != null)
            {
                string selectedCity = city.ToString();

                switch (selectedCity)
                {
                    case "Рязань":
                        imagePath = "Images/Рязань.jpg";
                        break;

                    default:
                        break;
                }
            }

            return imagePath;
        }

        private string GetExcursionName(string selectedCity)
        {
            string excursionName = "Экскурсия по " + selectedCity.Humanize(LetterCasing.Title);
            return excursionName;
        }

        private List<string> GetPathImages()
        {
            string pathDir = Path.Combine(Environment.CurrentDirectory, "Images");

            List<string> result = new List<string>();
            foreach (var pathFile in Directory.GetFiles(pathDir))
            {
                result.Add(pathFile);
            }

            return result;
        }

        private List<string> GetListImages()
        {
            List<string> result = new List<string>();
            foreach (var path in _pathImages)
            {
                result.Add(Path.GetFileName(path));
            }

            return result;
        }
        #endregion
    }
}