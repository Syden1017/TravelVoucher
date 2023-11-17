using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TravelVoucher.Tools
{
    public class Tour : INotifyPropertyChanged
    {
        private string _name;
        private DateTime _date;
        private decimal _price;
        private ImageSource _imagePath;
        private string _selectedCity;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public string SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
                LoadImage();
            }
        }

        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public ImageSource CityImage
        {
            get
            {
                return _imagePath;
            }

            set
            {
                if (_imagePath != value)
                {
                    _imagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }

        private void LoadImage()
        {
            string imageName = $"Images/{SelectedCity}.jpg";
            CityImage = new BitmapImage(new Uri($"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/{imageName}"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}