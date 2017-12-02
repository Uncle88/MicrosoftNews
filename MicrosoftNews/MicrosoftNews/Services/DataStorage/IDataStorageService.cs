using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.DataStorage
{
    public interface IDataStorageService
    {
        List<NewsItem> GetAllNews();
        void WriteItemToDB(NewsItem item);
        void WriteListToDB(ObservableCollection<NewsItem> list);
        void ClearDB();
    }
}
