﻿using System.Windows;
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
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 9;
        }
    }
}
