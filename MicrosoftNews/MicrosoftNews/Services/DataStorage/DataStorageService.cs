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
            dsConnection.CreateTable<Item>();
        }

        public List<Item> GetAllNews()
        {
            return dsConnection.Table<Item>().ToList();
        }

        public void WriteItemToDB(Item item)
        {
            dsConnection.Insert(item);
        }

        public void WriteListToDB(ObservableCollection<Item> list)
        {
            dsConnection.InsertAll(list);
        }

        public void ClearDB()
        {
            dsConnection.DeleteAll<Item>();
        }
    }
}
