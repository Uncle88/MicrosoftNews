using System;
using System.Collections.Generic;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.DataStorage
{
     interface IDataStorageService
    {
        List<NewsItems> GetAllNews();
        NewsItems GetItem();
    }
}
