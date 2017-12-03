using System.Collections.ObjectModel;
using System.Diagnostics;
using MicrosoftNews.Models;
using MicrosoftNews.Services.DataStorage;
using MicrosoftNews.Services.GettingData;
using MicrosoftNews.Views;
using Xamarin.Forms;

namespace MicrosoftNews.ViewModels
{
    public class NewsListViewModel : ViewModelBase
    {
        private IGettingDataService _gdService;
        private IDataStorageService _dstorageService;

        private ObservableCollection<NewsItem> _item;
        private NewsItem _itemDescription;
        private ObservableCollection<NewsItem> tempList;

        public NewsListViewModel()
        {
            _gdService = new GettingDataService();
            _dstorageService = new DataStorageService();

            _item = _gdService.GetData();
            _dstorageService.ClearDB();
            _dstorageService.WriteListToDB(_item);
            Items = new ObservableCollection<NewsItem>(_dstorageService.GetAllNews());
        }

        public INavigation Navigation { get; set; }

        public  ObservableCollection<NewsItem> Items
        {
            get 
            {
                return tempList;
            }
            set
            {
                if (tempList != value)
                    tempList = value;
                OnPropertyChanged();
            }
        }

        public NewsItem ItemDescription
        {
            get
            {
                return _itemDescription;
            }
            set
            {
                if ( value != _itemDescription)
                    _itemDescription = value;
                OnPropertyChanged();
                OnItemSelected();
            }
        }

        async void OnItemSelected()
        {
            //var item = args.SelectedItem as NewsItem;
            //if (item == null)
                //return;
            await Navigation.PushAsync(new DetailsListView(new DetailsListViewModel(ItemDescription)));
            //item.SelectedItem = null;
        }
    }
}
