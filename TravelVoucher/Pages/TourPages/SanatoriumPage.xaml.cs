using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for SanatoriumPage.xaml
    /// </summary>
    public partial class SanatoriumPage : Page
    {
        public SanatoriumPage()
        {
            InitializeComponent();
            string workingDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            string fileName = workingDirectory + @"txt-cities-russia.txt";

            cBoxFrom.ItemsSource = File.ReadAllLines(fileName);
            cBoxTo.ItemsSource = File.ReadAllLines(fileName);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 6;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }

        private void btnBuyTicket_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
