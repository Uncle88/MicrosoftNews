using System.Collections.ObjectModel;
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
        private IRestService _restService;
        private IDataStorageService _dstorageService;

        private Item _currentItem;
        private ObservableCollection<Item> _titlesList;

        public NewsListViewModel()
        {
            DataTransformation();
        }

        public async Task DataTransformation()
        {
            _restService = new RestService();
            _dstorageService = new DataStorageService();

            _dstorageService.ClearDB();

            Task<ObservableCollection<Item>> item = _restService.GetData();
            ObservableCollection<Item> tem = await item;
            _dstorageService.WriteListToDB(tem);
            Titles = new ObservableCollection<Item>(_dstorageService.GetAllNews());
        }

        public INavigation Navigation { get; set; }

        public  ObservableCollection<Item> Titles
        {
            get 
            {
                return _titlesList;
            }
            set
            {
                if (_titlesList != value)
                    _titlesList = value;
                OnPropertyChanged();
            }
        }

        public Item CurrentItem
        {
            get
            {
                return _currentItem;
            }
            set
            {
                if ( value != _currentItem)
                    _currentItem = value;
                OnItemSelected();
                OnPropertyChanged();
            }
        }

        async void OnItemSelected()
        {
            //var item = args.SelectedItem as NewsItem;
            //if (item == null)
                //return;
            await Navigation.PushAsync(new DetailsListView(new DetailsListViewModel(CurrentItem)));
            //item.SelectedItem = null;
        }
    }
}
