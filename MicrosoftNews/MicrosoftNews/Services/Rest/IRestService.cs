using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Xml.Linq;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.GettingData
{
    public interface IRestService
    {
        Task<ObservableCollection<Item>> GetData();
    }
}
