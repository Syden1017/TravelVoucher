﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace TravelVoucher.Tools
{
    public partial class Tour
    {
        private DateTime _date;
        private decimal _price;
        private string _imagePath;

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

        public string ImagePath
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}