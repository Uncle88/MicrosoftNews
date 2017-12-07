using System.Collections.Generic;
using System.Collections.ObjectModel;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.DataStorage
{
    public interface IDataStorageService
    {
        List<Item> GetList();
        void WriteListToDB(ObservableCollection<Item> list);
        void ClearDB();
    }
}
