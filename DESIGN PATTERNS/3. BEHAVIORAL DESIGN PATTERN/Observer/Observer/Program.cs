using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Program
    {
        public interface INewsPublisher
        {
            void AddSubscriber(INewsSubscriber subscriber);
            void RemoveSubscriber(INewsSubscriber subscriber);
            void NotifySubscribers(string newsUpdate);
        }

        public class NewsAgency : INewsPublisher
        {
            private List<INewsSubscriber> _subscribers = new List<INewsSubscriber>();

            public void AddSubscriber(INewsSubscriber subscriber)
            {
                _subscribers.Add(subscriber);
            }

            public void RemoveSubscriber(INewsSubscriber subscriber)
            {
                _subscribers.Remove(subscriber);
            }

            public void NotifySubscribers(string newsUpdate)
            {
                foreach (var subscriber in _subscribers)
                {
                    subscriber.Update(newsUpdate);
                }
            }
        }

        public interface INewsSubscriber
        {
            void Update(string newsUpdate);
        }

        public class EmailSubscriber : INewsSubscriber
        {
            private string _email;

            public EmailSubscriber(string email)
            {
                _email = email;
            }

            public void Update(string newsUpdate)
            {
                Console.WriteLine($"Sending email to {_email}: {newsUpdate}");
            }
        }

        public class SmsSubscriber : INewsSubscriber
        {
            private string _phoneNumber;

            public SmsSubscriber(string phoneNumber)
            {
                _phoneNumber = phoneNumber;
            }

            public void Update(string newsUpdate)
            {
                Console.WriteLine($"Sending SMS to {_phoneNumber}: {newsUpdate}");
            }
        }


        
            static void Main(string[] args)
            {
                NewsAgency newsAgency = new NewsAgency();

                INewsSubscriber emailSubscriber = new EmailSubscriber("user@example.com");
                INewsSubscriber smsSubscriber = new SmsSubscriber("+1234567890");

                newsAgency.AddSubscriber(emailSubscriber);
                newsAgency.AddSubscriber(smsSubscriber);

                newsAgency.NotifySubscribers("Breaking News: Important announcement!");
            }
        }

    }


