using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TravelVoucher.Tools;
using WpfApp1.Tools;
using Xceed.Wpf.Toolkit;

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
        }

        private void cBoxTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedItem = (String)cBoxTo.SelectedItem;

            if (selectedItem != null)
            {
                string selectedCity = selectedItem.ToString();

                switch (selectedCity)
                {
                    case "Рязань":
                        imagePath = "Images/Рязань.jpg";
                        break;

                    default:
                        break;
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }

        private void CalculatePrice()
        {
            int price = 0;

            string selectedItem = (String)cBoxExcursionType.SelectedItem;

            if (selectedItem != null)
            {
                string selectedExcursionType = selectedItem.ToString();

                switch(selectedExcursionType) 
                {
                    case "обзорная":
                        price = 1800 * Convert.ToInt32(upDownTourist.Text);
                        break;

                    case "историческая":
                        price = 2400 * Convert.ToInt32(upDownTourist.Text);
                        break;

                    case "городская":
                        price = 3000 * Convert.ToInt32(upDownTourist.Text);
                        break;
                    
                    case "загородная":
                        price = 3400 * Convert.ToInt32(upDownTourist.Text);
                        break;

                    case "музейная":
                        price = 2000 * Convert.ToInt32(upDownTourist.Text);
                        break;

                    case "учебная":
                        price = 800 * Convert.ToInt32(upDownTourist.Text);
                        break;
                }
            }
        }
    }
}