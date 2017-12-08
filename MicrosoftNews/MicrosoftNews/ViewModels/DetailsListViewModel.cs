using MicrosoftNews.Models;
using Xamarin.Forms;

namespace MicrosoftNews.ViewModels
{
    public class DetailsListViewModel : ViewModelBase
    {
        public DetailsListViewModel(string newsDescription)
        {
            _webView = new WebView();
            var _htmlViewSource = new HtmlWebViewSource();
            _htmlViewSource.Html = newsDescription;
            _webView.Source = _htmlViewSource;
        }

        WebView _webView;

        public WebView WebViewSource
        {
            get
            {
                return _webView;
            }
            set
            {
                _webView = value;
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