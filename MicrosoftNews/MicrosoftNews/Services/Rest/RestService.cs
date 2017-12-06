using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.GettingData
{
    public class RestService : IRestService
    {
        public async Task<ObservableCollection<Item>> GetData()
        {

            ObservableCollection<Item> Items;
            var client = new HttpClient();
            var response = await client.GetStreamAsync("https://news.microsoft.com/feed/"); 
            using (XmlReader reader = XmlReader.Create(response)) 
            { 
                XmlSerializer serializer = new XmlSerializer(typeof(Rss), new XmlRootAttribute("rss")); 
                var result = serializer.Deserialize(reader) as Rss;
                Items = new ObservableCollection<Item>(result.Channel.Item); 
            }
            if (Items == null)
            {
                Items = new ObservableCollection<Item>(); 
            }
            return Items;
        }
    }
}
