using System;
using System.IO;
using MicrosoftNews.iOS.Services.DataStoragePath;
using MicrosoftNews.Services.DataStoragePath;

[assembly: Xamarin.Forms.Dependency(typeof(DataStoragePathServiceiOS))]
namespace MicrosoftNews.iOS.Services.DataStoragePath
{
    public class DataStoragePathServiceiOS : IDataStoragePathService
    {
        public string DataStoragePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MicrosoftNewsDB.db");
    }
}
