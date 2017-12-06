using System.Collections.Generic;
using System.Xml.Serialization;
using SQLite;

namespace MicrosoftNews.Models
{

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }
    [XmlRoot(ElementName = "rss")]
    public class Rss
    {
        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }
    }
}

