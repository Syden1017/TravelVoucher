﻿using System.Windows;
using System.Windows.Controls;
using TravelVoucher.Pages.PopUpMenuPages;
using WpfApp1.Tools;

namespace TravelVoucher.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 1;
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new AccountPage());
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new SettingsPage());
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Остались вопросы?" +
                "\nВы можете задать их по номеру телефона: 89209891107",
                "Поддержка",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void listViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "listViewItemHome":
                    MessageBox.Show(
                        "Невозможно перейти на главную страницу." +
                        "\nПопробуйте перейти на другую страницу и повторить попытку",
                        "Ошибка перехода",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                        );
                    break;

                case "listViewItemFindTour":
                    Navigation.frmObj.Navigate(new FindTour());
                    break;

                case "listViewItemTickets":
                    Navigation.frmObj.Navigate(new MyTickets());
                    break;

                default:
                    break;
            }
        }
    }
}