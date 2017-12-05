using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using MicrosoftNews.Models;
using Newtonsoft.Json;

namespace MicrosoftNews.Services.GettingData
{
    public class RestService : IRestService
    {
        //public ObservableCollection<NewsItem> GetData()
        //{
        //   var Items = new ObservableCollection<NewsItem>()
        //    {
        //        new NewsItem{Text = "New fiches", DescriptionNews = "In Xamarin Forms there are a lot of MVVM frameworks that you can use to develop better code " +
        //                                                             "based on MVVM pattern, to mention just a few: Prism, MvvmLight, FreshMvvm, MvvmCross, Exrin, etc."},
        //        new NewsItem{Text = "MicrosoftNews", DescriptionNews = "Reduce risk with multiple layers of security right in the operating system for on-premises and cloud protection."},
        //        new NewsItem{Text = "Windows", DescriptionNews = "Get a Windows 10 development environment.Start building Universal Windows Platform apps quickly using a virtual machine."},
        //        new NewsItem{Text = "WinPhone", DescriptionNews = "Lightweight and powerful with unprecedented performance in a laptop this size. Get ideas down fast " +
        //                                                            "with a backlit keyboard and a display designed for touch and Surface Pen."},
        //        new NewsItem{Text = "FAQ", DescriptionNews = "A product key is a 25-character code that comes with a Microsoft Office product. " +
        //                                                     "The product key allows you to install and activate the Office product on your PC."}
        //    };
        //    return Items;
        //}

        public async Task<ObservableCollection<Item>> GetData()
        {
            ObservableCollection<Item> Items;
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://news.microsoft.com/feed/");


            using (TextReader reader = new StringReader(response))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Item>));
                Items = (ObservableCollection<Item>)serializer.Deserialize(reader);
            }

            if (Items == null)
            {
                Items = new ObservableCollection<Item>();
            }

            return Items;



            //var Items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(response);
            //return Items;

            //Uri geturi = new Uri("https://news.microsoft.com/feed/"); //replace your xml url  
            //HttpClient client = new HttpClient();
            //HttpResponseMessage responseGet = await client.GetAsync(geturi);
            //string response = await responseGet.Content.ReadAsStringAsync();//Getting response 
            //var Items = JsonConvert.DeserializeObject<ObservableCollection<NewsItem>>(response);
            //return Items;
        }
    }
}
