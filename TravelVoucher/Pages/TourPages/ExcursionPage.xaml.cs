using Humanizer;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
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
            DateTime selectedDate = datePickerExcursion.SelectedDate ?? DateTime.Now;
            string selectedCity = cBoxTo.SelectedItem.ToString();
            string name = GetExcursionName(selectedCity);
            double calculatedPrice = CalculatePrice();
            string img = GetImagePath(selectedCity);

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
        private double CalculatePrice()
        {
            double price = 0.00;

            string selectedItem = (String)cBoxExcursionType.SelectedItem;

            if (selectedItem != null)
            {
                string selectedExcursionType = selectedItem.ToString();

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

        private string GetImagePath(string city)
        {
            string imagePath = "";

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
        #endregion
    }
}