using System;
using System.Threading.Tasks;

namespace MicrosoftNews.Services.Login
{
    public interface ILoginService
    {
       Task Login(string login, string password);
    }
}
