using System.Windows;
using System.Windows.Input;
using TravelVoucher.Pages;
using WpfApp1.Tools;

namespace TravelVoucher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Настройка контентной части
            Navigation.frmObj = frmMain;
            frmMain.Navigate(new LoginPage());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show(
               "Действительно хотите завершить работу с программой?",
               "Выход из программы",
               MessageBoxButton.YesNo,
               MessageBoxImage.Question,
               MessageBoxResult.Yes) == MessageBoxResult.No;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void frmMain_ContentRendered(object sender, System.EventArgs e)
        {
            if (Navigation.id != 0)
            {
                btnMaximize.Visibility = Visibility.Visible;
            }
            else
            {
                btnMaximize.Visibility = Visibility.Hidden;
            }
        }
    }
}