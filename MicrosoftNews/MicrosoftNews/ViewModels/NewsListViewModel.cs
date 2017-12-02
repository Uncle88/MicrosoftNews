using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
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
        private List<NewsItem> tempList;

        public NewsListViewModel()
        {
            _gdService = new GettingDataService();
            _dstorageService = new DataStorageService();

            _item = _gdService.GetData();
            _dstorageService.ClearDB();
            _dstorageService.WriteListToDB(_item);
            Items = _dstorageService.GetAllNews();

            Task.Run(async() => 
            {
                await Task.Delay(10000);
                tempList[0] = new NewsItem { Text = "Pipiska", DescriptionNews ="lsakjdfhasdjkf;aljksdf" };
                OnPropertyChanged(nameof(Items));
            });
        }

        public INavigation Navigation { get; set; }

        public  List<NewsItem> Items
        {
            get 
            {
                Debug.WriteLine(tempList[0].Text);
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

        void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

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
