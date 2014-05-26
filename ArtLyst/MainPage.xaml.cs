using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ArtLyst.ViewModels;

namespace ArtLyst
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var selected = (FrameworkElement)sender;
            var item = (ItemViewModel)selected.DataContext;
            var index = App.ViewModel.Items.IndexOf(item);
            NavigationService.Navigate(
                new Uri("/ItemPage.xaml?selected=" + index, UriKind.Relative));
        }
    }
}