using System;

namespace Comportamiento.Domain
{
    /// <summary>
    /// Data class representing news information
    /// </summary>
    public class NewsData
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Category { get; set; }

        public NewsData(string title, string content, string category)
        {
            Title = title;
            Content = content;
            Category = category;
            PublishedDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Title} ({Category}) - {PublishedDate:yyyy-MM-dd HH:mm}";
        }
    }
}