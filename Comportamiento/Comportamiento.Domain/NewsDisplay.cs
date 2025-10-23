using System;

namespace Comportamiento.Domain
{
    /// <summary>
    /// Concrete observer that represents a news display system
    /// </summary>
    public class NewsDisplay : IObserver<NewsData>
    {
        private readonly string _displayName;

        public NewsDisplay(string displayName)
        {
            _displayName = displayName;
        }

        public void Update(NewsData data)
        {
            Console.WriteLine($"Displaying on {_displayName}: {data.Title} - {data.Content}");
            // Here you would implement actual display logic
        }
    }
}