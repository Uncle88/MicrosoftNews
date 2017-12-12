using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.Rest
{
    public interface IRestService
    {
        Task<ObservableCollection<Item>> GetData();
    }
}
