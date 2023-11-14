using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for BusTourPage.xaml
    /// </summary>
    public partial class BusTourPage : Page
    {
        public BusTourPage()
        {
            InitializeComponent();
            string workingDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            string fileName = workingDirectory + @"txt-cities-russia.txt";

            cBoxFrom.ItemsSource = File.ReadAllLines(fileName);
            cBoxRoute.ItemsSource = File.ReadAllLines(fileName);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 9;
        }

        private void btnBuyTicket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }

        private void ListViewItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}