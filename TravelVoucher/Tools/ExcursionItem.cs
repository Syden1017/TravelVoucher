using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace TravelVoucher.Tools
{
    public class ExcursionItem
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Price { get; set; }

        public BitmapImage CityImage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}