using System;

namespace Comportamiento.Domain
{
    /// <summary>
    /// Concrete observer that represents an SMS subscriber
    /// </summary>
    public class SMSSubscriber : IObserver<NewsData>
    {
        private readonly string _phoneNumber;

        public SMSSubscriber(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public void Update(NewsData data)
        {
            Console.WriteLine($"Sending SMS to {_phoneNumber}: {data.Title}");
            // Here you would implement actual SMS sending logic
        }
    }
}