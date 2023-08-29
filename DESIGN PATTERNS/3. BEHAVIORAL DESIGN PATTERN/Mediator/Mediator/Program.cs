using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        public interface IChatMediator
        {
            void SendMessage(User sender, string message);
        }

        public class ChatRoom : IChatMediator
        {
            public void SendMessage(User sender, string message)
            {
                Console.WriteLine($"{sender.Name} sends message: {message}");
            }
        }

        public class User
        {
            public string Name { get; }
            private IChatMediator _mediator;

            public User(string name, IChatMediator mediator)
            {
                Name = name;
                _mediator = mediator;
            }

            public void SendMessage(string message)
            {
                _mediator.SendMessage(this, message);
            }
        }


       
            static void Main(string[] args)
            {
                IChatMediator chatRoom = new ChatRoom();

                User user1 = new User("User 1", chatRoom);
                User user2 = new User("User 2", chatRoom);
                User user3 = new User("User 3", chatRoom);

                user1.SendMessage("Hello, everyone!");
                user2.SendMessage("Hi there!");
                user3.SendMessage("Hey, folks!");
            }
        }

    }

