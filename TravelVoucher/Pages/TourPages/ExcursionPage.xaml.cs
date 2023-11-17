using System;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Tour> Tours { get; set; }

        public ExcursionPage()
        {
            InitializeComponent();
            string workingDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            string fileName = workingDirectory + @"txt-cities-russia.txt";

            cBoxFrom.ItemsSource = File.ReadAllLines(fileName);
            cBoxTo.ItemsSource = File.ReadAllLines(fileName);

            Tours = new ObservableCollection<Tour>();
            DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 5;
        }

        private void btnFindTickets_Click(object sender, RoutedEventArgs e)
        {
            Tours.Add(new Tour
            {
                Date = datePickerExcursion.SelectedDate ?? DateTime.Now,
                
            });
        }

        private void cBoxTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedItem = (String)cBoxTo.SelectedItem;

            if (selectedItem != null)
            {
                string selectedCity = selectedItem.ToString();

                string imagePath = "";

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
    }
}