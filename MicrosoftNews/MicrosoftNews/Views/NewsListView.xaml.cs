using System;
using System.Collections.ObjectModel;
using MicrosoftNews.Models;
using MicrosoftNews.ViewModels;
using Xamarin.Forms;

namespace MicrosoftNews.Views
{
    public partial class NewsListView : ContentPage
    {
        private NewsListViewModel viewModel;
        public NewsListView()
        {
            InitializeComponent();
            list.ItemSelected += OnItemSelected;
            BindingContext = viewModel = new NewsListViewModel() { Navigation = this.Navigation };
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as NewsItems;
            if (item == null)
            {
                // the item was deselected
                return;
            }

            // Navigate to the detail page
            await Navigation.PushAsync(new DetailsListView(new DetailsListViewModel(item)));

            // Manually deselect item
            list.SelectedItem = null;
        }
    }
}
