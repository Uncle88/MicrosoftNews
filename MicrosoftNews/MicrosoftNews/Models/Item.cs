using System.Xml.Serialization;
using SQLite;

namespace MicrosoftNews.Models
{
    [XmlRoot(ElementName = "item")]
    public class Item 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [XmlElement(ElementName= "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
    }
}
