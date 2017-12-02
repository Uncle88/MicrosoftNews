using System;
using System.IO;
using MicrosoftNews.Droid.Services.DataStoragePath;
using MicrosoftNews.Services.DataStoragePath;

[assembly: Xamarin.Forms.Dependency(typeof(DataStoragePathServiceAndroid))]
namespace MicrosoftNews.Droid.Services.DataStoragePath
{
    public class DataStoragePathServiceAndroid : IDataStoragePathService
    {
        public string DataStoragePath =>Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MicrosoftNewsDB.db");
    }
}
