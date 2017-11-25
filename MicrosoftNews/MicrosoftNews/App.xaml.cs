using MicrosoftNews.Views;
using Xamarin.Forms;

namespace MicrosoftNews
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var content = new NewsListView();
            MainPage = new NavigationPage(content);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
