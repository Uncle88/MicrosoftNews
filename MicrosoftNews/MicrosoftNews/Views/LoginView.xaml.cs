using System;
using System.Collections.Generic;
using MicrosoftNews.ViewModels;
using Xamarin.Forms;

namespace MicrosoftNews.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
