using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MicrosoftNews.Constants;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.GettingData
{
    public class RestService : IRestService
    {
        public async Task<ObservableCollection<Item>> GetData()
        {
            ObservableCollection<Item> Items;
            var client = new HttpClient();
            var response = await client.GetStreamAsync(MicrosoftConstants.URLREQUEST); 
            using (XmlReader reader = XmlReader.Create(response)) 
            { 
                XmlSerializer serializer = new XmlSerializer(typeof(Rss), new XmlRootAttribute(MicrosoftConstants.XMLATTRIBUTE)); 
                var result = serializer.Deserialize(reader) as Rss;
                try
                {
                    Items = new ObservableCollection<Item>(result.Channel.Item);
                }
                catch
                {
                    Items = new ObservableCollection<Item>();
                }
                return Items;
            }
        }
    }
}
