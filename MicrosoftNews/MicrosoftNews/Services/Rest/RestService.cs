using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MicrosoftNews.Constants;
using MicrosoftNews.Models;

namespace MicrosoftNews.Services.Rest
{
    public class RestService : IRestService
    {
        public async Task<ObservableCollection<Item>> GetData()
        {
            var _client = new HttpClient();
            var response = await _client.GetStreamAsync(MicrosoftConstants.URLREQUEST); 
            using (XmlReader reader = XmlReader.Create(response)) 
            { 
                XmlSerializer serializer = new XmlSerializer(typeof(Rss), new XmlRootAttribute(MicrosoftConstants.XMLATTRIBUTE)); 
                var result = serializer.Deserialize(reader) as Rss;

                if (result?.Channel?.Item != null)
                {
                    return new ObservableCollection<Item>(result.Channel.Item);
                }
                return new ObservableCollection<Item>();
            }
        }
    }
}
