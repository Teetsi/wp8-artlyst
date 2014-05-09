using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ArtLyst.Resources;

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
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new ItemViewModel() {
                Title = "Polke Richter - Richter Polke",
                Date = "25 Apr - 07 Jul",
                ImageUrl = "http://artlyst.com/img/events/12896.jpg",
                Venue="Christie's (King Street)",
                Address="8 King Street, St. James's , London , SW1Y 6QT. UK",
                WebUrl="http://www.christies.com",
                Tel="020 7839 9060",
                Cost="free",
                Description="London – On 24 April 2014 Christie’s Mayfair will open Polke/Richter-Richter/Polke, celebrating two giants of painting: Gerhard Richter (b.1932) and Sigmar Polke (1941-2010). The show brings together 65 works from 30 collections to create the artists’ first joint show in almost 50 years, since their now legendary 1966 exhibition at Galerie h in Hanover. This show was a declaration of their intention to resurrect painting, a medium presumed dead, by deconstructing it and opening up new possibilities. Christie’s Polke/Richter-Richter/Polke reunites two of the works from this show (Flemish Crown, by Richter and Bavarian by Polke, illustrated below), as well as others from the period, and then surveys the artists’ careers since then, until Polke’s death."
            });
            this.Items.Add(new ItemViewModel() { Title = "Henri Matisse: The Cut Outs", Date = "25 Apr - 07 Jul", ImageUrl = "http://artlyst.com/img/events/8518.jpg" });
            this.Items.Add(new ItemViewModel() { Title = "Julian Schnabel", Date = "25 Apr - 07 Jul", ImageUrl = "http://artlyst.com/img/events/12909.jpg" });
            this.Items.Add(new ItemViewModel() { Title = "Andreas Gursky Landscapes", Date = "25 Apr - 07 Jul", ImageUrl = "http://artlyst.com/img/events/12446.jpg" });
            this.Items.Add(new ItemViewModel() { Title = "Alan Davie", Date = "25 Apr - 07 Jul", ImageUrl = "http://artlyst.com/img/events/12805.jpg" });

            this.IsDataLoaded = true;
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