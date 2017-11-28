using System;
using System.Collections.Generic;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.DataStorage
{
     interface IDataStorageService
    {
        List<NewsItem> GetAllNews();
        NewsItem GetItem();
    }
}
