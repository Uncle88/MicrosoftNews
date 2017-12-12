using MicrosoftNews.ViewModels;
using Xamarin.Forms;

namespace MicrosoftNews.Views
{
    public partial class DetailsListView : ContentPage
    {
        public  DetailsListView(DetailsListViewModel _detailViewModel)
        {
            InitializeComponent();
            this.BindingContext = _detailViewModel;
        }
    }
}