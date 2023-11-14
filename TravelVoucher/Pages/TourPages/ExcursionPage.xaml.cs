using System;
using System.Collections.ObjectModel;
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

            Tours = new ObservableCollection<Tour>();
            DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 5;
        }

        private void btnFindTickets_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = datePickerExcursion.SelectedDate ?? DateTime.Now;
            decimal price;

            string selectedCity = cBoxTo.SelectedItem.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }
    }
}