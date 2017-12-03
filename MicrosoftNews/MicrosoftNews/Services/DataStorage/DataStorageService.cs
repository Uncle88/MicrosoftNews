using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MicrosoftNews.Models;
using MicrosoftNews.Services.DataStoragePath;
using MicrosoftNews.Services.GettingData;
using SQLite;
using Xamarin.Forms;

namespace MicrosoftNews.Services.DataStorage
{
    public class DataStorageService : IDataStorageService
    {
        private readonly IDataStoragePathService _datastoragePathService = DependencyService.Get<IDataStoragePathService>();
        private readonly SQLiteConnection dsConnection;

        public DataStorageService()
        {
            dsConnection = new SQLiteConnection(_datastoragePathService.DataStoragePath);
            dsConnection.CreateTable<NewsItem>();
        }

        public List<NewsItem> GetAllNews()
        {
            return dsConnection.Table<NewsItem>().ToList();
        }

        public void WriteItemToDB(NewsItem item)
        {
            dsConnection.Insert(item);
        }

        public void WriteListToDB(ObservableCollection<NewsItem> list)
        {
            dsConnection.InsertAll(list);
        }

        public void ClearDB()
        {
            dsConnection.DeleteAll<NewsItem>();
        }
    }
}
