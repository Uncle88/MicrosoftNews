using SQLite;

namespace MicrosoftNews.Models
{
    public class NewsItem 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string DescriptionNews { get; set; }
    }
}
