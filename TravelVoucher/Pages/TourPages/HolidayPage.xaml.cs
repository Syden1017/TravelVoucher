using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for HolidayPage.xaml
    /// </summary>
    public partial class HolidayPage : Page
    {
        public HolidayPage()
        {
            InitializeComponent();
            string workingDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            string fileName = workingDirectory + @"txt-cities-russia.txt";

            cBoxFrom.ItemsSource = File.ReadAllLines(fileName);
            cBoxTo.ItemsSource = File.ReadAllLines(fileName);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 4;
        }

        private void btnBuyTicket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }
    }
}