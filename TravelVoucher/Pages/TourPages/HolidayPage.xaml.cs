using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using WpfApp1.Tools;
using Color = System.Windows.Media.Color;

namespace TravelVoucher.Pages.TourPages
{
    /// <summary>
    /// Interaction logic for HolidayPage.xaml
    /// </summary>
    public partial class HolidayPage : Page
    {

        public partial class Rating : UserControl
        {
            public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Rating", typeof(int), typeof(Rating),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RatingChanged)));

            private int _max = 5;

            public int Value
            {
                get
                {
                    return (int)GetValue(ValueProperty);
                }
                set
                {
                    if (value < 0)
                    {
                        SetValue(ValueProperty, 0);
                    }
                    else if (value > _max)
                    {
                        SetValue(ValueProperty, _max);
                    }
                    else
                    {
                        SetValue(ValueProperty, value);
                    }
                }
            }

            private static void RatingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                Rating item = sender as Rating;
                int newval = (int)e.NewValue;
                UIElementCollection childs = ((Grid)(item.Content)).Children;

                ToggleButton button = null;

                for (int i = 0; i < newval; i++)
                {
                    button = childs[i] as ToggleButton;
                    if (button != null)
                        button.IsChecked = true;
                }

                for (int i = newval; i < childs.Count; i++)
                {
                    button = childs[i] as ToggleButton;
                    if (button != null)
                        button.IsChecked = false;
                }

            }

        }

        public HolidayPage()
        {
            InitializeComponent();
            string workingDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            string fileName = workingDirectory + @"txt-cities-russia.txt";

            cBoxFrom.ItemsSource = File.ReadAllLines(fileName);
            cBoxTo.ItemsSource = File.ReadAllLines(fileName);
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Navigation.id = 4;
        }

        private void btnBuyTicket_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            var Numb = rnd.Next(0, 1000000);
            string Name = "Ваш билет" + $"Номер:{Numb}";
            string Sity = $"Направление: {cBoxFrom.Text} -> {cBoxTo.Text}";
            string Date = $"Дата - {DataPic.Text}";
            string Transport = $"Вид транспорта - {cBoxTransport.Text}";
            string Hotel = $"Отель - {cBoxHotel.Text}";
            string Pitanie = $"Питание - {cBoxFood.Text}";
            string ColHuman = $"Количество гостей - {txtBoxNumberOfGuests.Text}";


           
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frmObj.GoBack();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            int Value = newvalue;
        }

        private void ToggleButton_Click_1(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            int Value = newvalue;
        }

        private void ToggleButton_Click_2(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            int Value = newvalue;
        }

        private void ToggleButton_Click_3(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            int Value = newvalue;
        }

        private void ToggleButton_Click_4(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            int newvalue = int.Parse(button.Tag.ToString());
            int Value = newvalue;
        }
    }
}