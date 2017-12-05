using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.DataStorage
{
    public interface IDataStorageService
    {
        List<Item> GetAllNews();
        void WriteItemToDB(Item item);
        void WriteListToDB(ObservableCollection<Item> list);
        void ClearDB();
    }
}
