using System;
using System.Collections.ObjectModel;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.GettingData
{
    public interface IGettingDataService
    {
        ObservableCollection<NewsItem> GetData();
    }
}
