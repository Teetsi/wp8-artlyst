using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ArtLyst.Resources;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Windows;

namespace ArtLyst.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public async void LoadData()
        {
            var url = "http://freshart-static.cloudapp.net/recommended.xml";
            var client = new WebClient();

            try
            {
                string response = await client.DownloadStringTaskAsync(new Uri(url));
                var doc = XDocument.Parse(response);
                var list = from query in doc.Descendants("exhibition")
                           select new ItemViewModel
                           {
                               Title = (string)query.Element("title"),
                               ImageUrl = (string)query.Element("preview-image"),
                               Venue = (string)query.Element("venue"),
                               Address = (string)query.Element("address")
                           };

                list.ToList().ForEach(this.Items.Add);
                this.IsDataLoaded = true;
            }
            catch
            {
                MessageBox.Show(messageBoxText: "Cannot retrieve exhibition list",
                    caption: "Error",
                    button: MessageBoxButton.OK);
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