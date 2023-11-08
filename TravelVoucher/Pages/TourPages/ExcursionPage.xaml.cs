using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Tools;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for ExcursionPage.xaml
    /// </summary>
    public partial class ExcursionPage : Page
    {
        public ObservableCollection<Item> Items { get; set; }

        public ExcursionPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<Item>();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 5;
        }

        private void btnFindTickets_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = datePickerExcursion.SelectedDate ?? DateTime.Now;
            decimal price;


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }
    }
}