using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MicrosoftNews.Models;
using MicrosoftNews.Services.DataStorage;
using MicrosoftNews.Services.Rest;
using MicrosoftNews.Views;
using Xamarin.Forms;

namespace MicrosoftNews.ViewModels
{
    public class NewsListViewModel : ViewModelBase
    {
        readonly IRestService _restService;
        readonly IDataStorageService _dstorageService;

        private Item _selectedItem;
        private ObservableCollection<Item> _newsCollection;
        private bool _isBusy;

        public NewsListViewModel(INavigation navigation)
        {
            _restService = new RestService();
            _dstorageService = new DataStorageService();
            _navigation = navigation;

            DataTransformation();
        }

        public async Task DataTransformation()
        {
            IsBusy = true;
            _dstorageService.ClearDB();

            var newsItem = await _restService.GetData();
            _dstorageService.WriteListToDB(newsItem);

            try
            {
                Items = new ObservableCollection<Item>(_dstorageService.GetList());
                if (Items != null)
                {
                    IsBusy = false;
                }
            }
            catch
            {
                IsBusy = true;
            }
        }

        public INavigation _navigation { get; internal set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set 
            { 
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        public  ObservableCollection<Item> Items
        {
            get 
            {
                return _newsCollection;
            }
            set
            {
                if (_newsCollection != value)
                {
                    _newsCollection = value;
                    OnPropertyChanged(); 
                }
            }
        }

        public Item SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                    if (value != null)
                    {
                        OnItemSelected();
                    }
                }
            }
        }

        async void OnItemSelected()
        {
            await _navigation.PushAsync(new DetailsListView(SelectedItem.Description));
            SelectedItem = null;
        }
    }
}
