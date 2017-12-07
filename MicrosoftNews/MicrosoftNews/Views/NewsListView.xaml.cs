using MicrosoftNews.ViewModels;
using Xamarin.Forms;

namespace MicrosoftNews.Views
{
    public partial class NewsListView : ContentPage
    {
        public NewsListView()
        {
            InitializeComponent();
            BindingContext = new NewsListViewModel()
            {
                Navigation = this.Navigation
            };
        }
    }
}
