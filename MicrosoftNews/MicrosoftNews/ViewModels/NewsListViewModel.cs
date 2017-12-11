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

        private Item _selectedItem;
        private ObservableCollection<Item> _titlesList;
        private bool _isBusy;

        public NewsListViewModel()
        {
            DataTransformation();
        }

        public async Task DataTransformation()
        {
            IsBusy = true;
            _restService = new RestService();
            _dstorageService = new DataStorageService();
            _dstorageService.ClearDB();

            Task<ObservableCollection<Item>> item = _restService.GetData();
            ObservableCollection<Item> tem = await item;

            _dstorageService.WriteListToDB(tem);

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

        public INavigation Navigation { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set 
            { 
                _isBusy= value; 
                OnPropertyChanged();
            }
        }

        public  ObservableCollection<Item> Items
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

        public Item SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (value != null)
                {
                    OnItemSelected();
                }

            }
        }

        async void OnItemSelected()
        {
            await Navigation.PushAsync(new DetailsListView(new DetailsListViewModel(SelectedItem.Description)));
            SelectedItem = null;
        }
    }
}
