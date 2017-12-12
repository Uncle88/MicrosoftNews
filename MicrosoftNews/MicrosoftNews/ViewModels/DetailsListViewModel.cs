using Xamarin.Forms;

namespace MicrosoftNews.ViewModels
{
    public class DetailsListViewModel : ViewModelBase
    {
        private HtmlWebViewSource _htmlViewSource;

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
                if (value != _htmlViewSource)
                {
                    _htmlViewSource = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}