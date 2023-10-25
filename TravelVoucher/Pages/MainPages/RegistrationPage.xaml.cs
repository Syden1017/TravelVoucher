using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using TravelVoucher.Tools;
using WpfApp1.Tools;

namespace TravelVoucher.Pages.MainPages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 12;
        }

        private void txtBoxRegistrationLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBoxRegistrationLogin.Text == "")
            {
                txtBoxRegistrationLogin.Background = Brushes.LightCoral;
                txtBoxRegistrationLogin.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(txtBoxRegistrationLogin, 255, 242, 242);
                ColoredControl.SetBorderColor(txtBoxRegistrationLogin, 0, 0, 0);
            }
        }

        private void passBoxRegistration_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passBoxRegistration.Password == "")
            {
                passBoxRegistration.Background = Brushes.LightCoral;
                passBoxRegistration.BorderBrush = Brushes.Red;
            }
            else
            {
                ColoredControl.SetBackgroundColor(passBoxRegistration, 255, 242, 242);
                ColoredControl.SetBorderColor(passBoxRegistration, 0, 0, 0);

                passBoxRepeatPassword.Visibility = Visibility.Visible;
            }
        }

        private void btnCancelRegistration_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}