using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly SQLiteConnection _datastorageConnection;

        public DataStorageService()
        {
            _datastorageConnection = new SQLiteConnection(_datastoragePathService.DataStoragePath);
            _datastorageConnection.CreateTable<Item>();
        }

        public List<Item> GetList()
        {
            return _datastorageConnection.Table<Item>().ToList();
        }

        public void WriteListToDB(ObservableCollection<Item> list)
        {
            _datastorageConnection.InsertAll(list);
        }

        public void ClearDB()
        {
            _datastorageConnection.DeleteAll<Item>();
        }
    }
}
