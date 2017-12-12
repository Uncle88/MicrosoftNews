using MicrosoftNews.ViewModels;
using Xamarin.Forms;

namespace MicrosoftNews.Views
{
    public partial class DetailsListView : ContentPage
    {
        public  DetailsListView(string _description)
        {
            InitializeComponent();
            this.BindingContext = new DetailsListViewModel(_description);
        }
    }
}