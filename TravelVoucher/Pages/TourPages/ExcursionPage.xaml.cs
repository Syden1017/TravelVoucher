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
        string imagePath = Path.Combine("C:\\Users\\ИСП-32\\source\\repos\\Новая папка\\TravelVoucher\\", "Images");

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
            Tours.Add(new Tour
            {
                Date = datePickerExcursion.SelectedDate ?? DateTime.Now,
                
            });
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }
    }
}