using System;
using Microsoft.Identity.Client;
using MicrosoftNews.Services.Login;
using Xamarin.Forms;

namespace MicrosoftNews.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Command _clickCommand;
        private string _login;
        private string _password;
        private ILoginService _loginServiсe;

        public LoginViewModel()
        {
            _loginServiсe = new LoginService();
        }

        public string Login
        {
            get { return _login; }
            set
            {
                if (value != _login)
                {
                    _login = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public Command ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new Command(async (_) =>//
                {
                    if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                    {
                        return;
                    }
                    await _loginServiсe.Login(Login, Password);
                }));
            }
        }
    }
}
