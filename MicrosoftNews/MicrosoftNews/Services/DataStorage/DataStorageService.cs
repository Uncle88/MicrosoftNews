using System;
using System.Collections.Generic;
using System.Linq;
using MicrosoftNews.Models;
using MicrosoftNews.Services.DataStoragePath;
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
            dsConnection.CreateTable<NewsItems>();
        }

        public List<NewsItems> GetAllNews()
        {
            return dsConnection.Table<NewsItems>().ToList();
        }

        public NewsItems GetItem()
        {
            return dsConnection.Table<NewsItems>().FirstOrDefault();
        }
    }
}
