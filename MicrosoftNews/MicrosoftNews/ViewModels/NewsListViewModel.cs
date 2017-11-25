using System.Collections.ObjectModel;
using MicrosoftNews.Models;

namespace MicrosoftNews.ViewModels
{
    public class NewsListViewModel : ViewModelBase
    {
        private ObservableCollection<NewsItems> newsItem;

        public NewsListViewModel()
        {
            Items = new ObservableCollection<NewsItems>()
            {
                new NewsItems{Text = "New fiches"},
                new NewsItems{Text = "MicrosoftNews"},
                new NewsItems{Text = "Windows"},
                new NewsItems{Text = "WinPhone"},
                new NewsItems{Text = "FQ"}
            };
        }

        public ObservableCollection<NewsItems> Items
        {
            get 
            {
                return newsItem;
            }
            set
            {
                if (newsItem != value)
                    newsItem = value;
                OnPropertyChanged();
            }
        }
    }
}
