using System;
using System.Collections.Generic;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.DataStorage
{
    public interface IDataStorageService
    {
        List<NewsItems> GetAllNews();
        NewsItems GetItem();
    }
}
