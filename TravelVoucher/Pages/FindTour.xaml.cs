using System.Windows;
using System.Windows.Controls;
using WpfApp1.Tools;
using TravelVoucher.Pages.TourPages;
using TravelVoucher.Pages.PopUpMenuPages;

namespace TravelVoucher.Pages
{
    /// <summary>
    /// Логика взаимодействия для FindTour.xaml
    /// </summary>
    public partial class FindTour : Page
    {
        public FindTour()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 2;
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
                "\nВы можете задать их по номеру телефона: 89005063245",
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
                    Navigation.frmObj.Navigate(new HomePage());
                    break;

                case "listViewItemFindTour":
                    MessageBox.Show(
                        "Невозможно перейти на страницу выбора путёвки." +
                        "\nПопробуйте перейти на другую страницу и повторить попытку",
                        "Ошибка перехода",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                        );
                    break;

                case "listViewItemTickets":
                    Navigation.frmObj.Navigate(new MyTickets());
                    break;

                default:
                    break;
            }
        }

        private void btnHoliday_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new HolidayPage());
        }
        
        private void btnExcursion_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new ExcursionPage());
        }

        private void btnSanatorium_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new SanatoriumPage());
        }

        private void btnShopping_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new ShoppingPage());
        }

        private void btnCruise_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new CruisePage());
        }

        private void btnBusTour_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.Navigate(new BusTourPage());
        }
    }
}