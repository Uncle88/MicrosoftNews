using MicrosoftNews.Models;
using Xamarin.Forms;

namespace MicrosoftNews.ViewModels
{
    public class DetailsListViewModel : ViewModelBase
    {
        public DetailsListViewModel(string newsDescription)
        {
            _htmlViewSource = new HtmlWebViewSource();
            _htmlViewSource.Html = newsDescription;
        }

        HtmlWebViewSource _htmlViewSource;
        public HtmlWebViewSource WebViewSource
        {
            get
            {
                return _htmlViewSource;
            }
            set
            {
                if (value != _htmlViewSource)
                {
                    _htmlViewSource = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}