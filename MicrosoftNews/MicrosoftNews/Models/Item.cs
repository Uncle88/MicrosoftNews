using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace MicrosoftNews.Models
{

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        public bool IsVisible { get; internal set; }

        public static implicit operator Item(ObservableCollection<Item> v)
        {
            throw new NotImplementedException();
        }
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

