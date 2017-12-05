using MicrosoftNews.ViewModels;
using Xamarin.Forms;

namespace MicrosoftNews.Views
{
    public partial class DetailsListView : ContentPage
    {
        public DetailsListViewModel _dLViewModel { get; set; }

        public DetailsListView(DetailsListViewModel _dLViewModel)
        {
            InitializeComponent();
            this.BindingContext = this._dLViewModel = _dLViewModel;
        }

        //public DetailsListView()
        //{
        //}
    }
}