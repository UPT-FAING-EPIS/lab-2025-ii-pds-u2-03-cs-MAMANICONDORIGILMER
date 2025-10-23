using System.Collections.Generic;

namespace Comportamiento.Domain
{
    /// <summary>
    /// Concrete subject that represents a news agency
    /// </summary>
    public class NewsAgency : ISubject<NewsData>
    {
        private readonly List<IObserver<NewsData>> _observers;
        private NewsData? _latestNews;

        public NewsAgency()
        {
            _observers = new List<IObserver<NewsData>>();
        }

        public void Attach(IObserver<NewsData> observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver<NewsData> observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(NewsData data)
        {
            _latestNews = data;
            foreach (var observer in _observers)
            {
                observer.Update(data);
            }
        }

        /// <summary>
        /// Publishes new news and notifies all subscribers
        /// </summary>
        /// <param name="title">News title</param>
        /// <param name="content">News content</param>
        /// <param name="category">News category</param>
        public void PublishNews(string title, string content, string category)
        {
            var newsData = new NewsData(title, content, category);
            Notify(newsData);
        }

        /// <summary>
        /// Gets the latest published news
        /// </summary>
        public NewsData? GetLatestNews()
        {
            return _latestNews;
        }

        /// <summary>
        /// Gets the number of subscribers
        /// </summary>
        public int SubscriberCount => _observers.Count;
    }
}