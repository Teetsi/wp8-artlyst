using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ArtLyst.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string _title;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _date;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value != _date)
                {
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        private string _imageUrl;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                if (value != _imageUrl)
                {
                    _imageUrl = value;
                    NotifyPropertyChanged("ImageUrl");
                }
            }
        }

        private string _venue;
        public string Venue
        {
            get
            {
                return _venue;
            }
            set
            {
                if (value != _venue)
                {
                    _venue = value;
                    NotifyPropertyChanged("Venue");
                }
            }
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    NotifyPropertyChanged("Address");
                }
            }
        }

        private string _webUrl;
        public string WebUrl
        {
            get
            {
                return _webUrl;
            }
            set
            {
                if (value != _webUrl)
                {
                    _webUrl = value;
                    NotifyPropertyChanged("WebUrl");
                }
            }
        }

        private string _tel;
        public string Tel
        {
            get
            {
                return _tel;
            }
            set
            {
                if (value != _tel)
                {
                    _tel = value;
                    NotifyPropertyChanged("Tel");
                }
            }
        }

        private string _cost;
        public string Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (value != _cost)
                {
                    _cost = value;
                    NotifyPropertyChanged("Cost");
                }
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}