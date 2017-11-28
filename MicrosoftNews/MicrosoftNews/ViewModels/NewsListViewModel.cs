using System.Collections.ObjectModel;
using MicrosoftNews.Models;
using MicrosoftNews.Views;
using Xamarin.Forms;

namespace MicrosoftNews.ViewModels
{
    public class NewsListViewModel : ViewModelBase
    {
        public INavigation Navigation { get; set; }
        ObservableCollection<NewsItem> newsItem;

        public NewsListViewModel()
        {
            Items = new ObservableCollection<NewsItem>()
            {
                new NewsItem{Text = "New fiches", DescriptionNews = "In Xamarin Forms there are a lot of MVVM frameworks that you can use to develop better code " +
                                                                     "based on MVVM pattern, to mention just a few: Prism, MvvmLight, FreshMvvm, MvvmCross, Exrin, etc."},
                new NewsItem{Text = "MicrosoftNews", DescriptionNews = "Reduce risk with multiple layers of security right in the operating system for on-premises and cloud protection."},
                new NewsItem{Text = "Windows", DescriptionNews = "Get a Windows 10 development environment.Start building Universal Windows Platform apps quickly using a virtual machine."},
                new NewsItem{Text = "WinPhone", DescriptionNews = "Lightweight and powerful with unprecedented performance in a laptop this size. Get ideas down fast " +
                                                                    "with a backlit keyboard and a display designed for touch and Surface Pen."},
                new NewsItem{Text = "FAQ", DescriptionNews = "A product key is a 25-character code that comes with a Microsoft Office product. " + 
                                                             "The product key allows you to install and activate the Office product on your PC."}
            };
        }

        public ObservableCollection<NewsItem> Items
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
