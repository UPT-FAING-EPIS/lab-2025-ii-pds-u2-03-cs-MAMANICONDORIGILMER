using System;

namespace Comportamiento.Domain
{
    /// <summary>
    /// Concrete observer that represents an email subscriber
    /// </summary>
    public class EmailSubscriber : IObserver<NewsData>
    {
        private readonly string _email;

        public EmailSubscriber(string email)
        {
            _email = email;
        }

        public void Update(NewsData data)
        {
            Console.WriteLine($"Sending email to {_email}: {data.Title} - {data.Content}");
            // Here you would implement actual email sending logic
        }
    }
}