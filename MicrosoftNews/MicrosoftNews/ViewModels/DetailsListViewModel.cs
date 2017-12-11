using MicrosoftNews.Models;
using Xamarin.Forms;

namespace MicrosoftNews.ViewModels
{
    public class DetailsListViewModel : ViewModelBase
    {
        HtmlWebViewSource _htmlViewSource;
        public DetailsListViewModel(string newsDescription)
        {
            _htmlViewSource = new HtmlWebViewSource();
            _htmlViewSource.Html = newsDescription;
        }

        public HtmlWebViewSource WebViewSource
        {
            get
            {
                return _htmlViewSource;
            }
            set
            {
                _htmlViewSource = value;
                OnPropertyChanged();
            }
        }
    }
}



//string _descriptionNews;
//public string Description 
//{
//    get
//    {
//        return _descriptionNews;
//    }
//    set
//    {
//        if (_descriptionNews != value)
//        {
//            _descriptionNews = value;
//            OnPropertyChanged();
//        }
//    }
//}
//public DetailsListViewModel(string newsDescription)
//{
//_descriptionNews = newsDescription;
//}