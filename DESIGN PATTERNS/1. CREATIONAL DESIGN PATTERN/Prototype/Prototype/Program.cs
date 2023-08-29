using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {

        public abstract class GreetingCardPrototype
        {
            public abstract GreetingCardPrototype Clone();

            public abstract void SetRecipient(string recipient);
            public abstract void SetMessage(string message);
            public abstract void PrintCard();
        }


        public class BirthdayCard : GreetingCardPrototype
        {
            private string recipient;
            private string message;

            public override GreetingCardPrototype Clone()
            {
                return new BirthdayCard();
            }

            public override void SetRecipient(string recipient)
            {
                this.recipient = recipient;
            }

            public override void SetMessage(string message)
            {
                this.message = message;
            }

            public override void PrintCard()
            {
                Console.WriteLine($"Birthday Card for {recipient}: {message}");
            }
        }

        public class AnniversaryCard : GreetingCardPrototype
        {
            private string recipient;
            private string message;

            public override GreetingCardPrototype Clone()
            {
                return new AnniversaryCard();
            }

            public override void SetRecipient(string recipient)
            {
                this.recipient = recipient;
            }

            public override void SetMessage(string message)
            {
                this.message = message;
            }

            public override void PrintCard()
            {
                Console.WriteLine($"Anniversary Card for {recipient}: {message}");
            }
        }



        static void Main(string[] args)
        {
            BirthdayCard originalBirthdayCard = new BirthdayCard();
            originalBirthdayCard.SetRecipient("Alice");
            originalBirthdayCard.SetMessage("Happy Birthday!");

            BirthdayCard clonedBirthdayCard = (BirthdayCard)originalBirthdayCard.Clone();
            clonedBirthdayCard.SetRecipient("Bob");
            clonedBirthdayCard.SetMessage("Wishing you a fantastic day!");

            AnniversaryCard originalAnniversaryCard = new AnniversaryCard();
            originalAnniversaryCard.SetRecipient("Carol and Dave");
            originalAnniversaryCard.SetMessage("Congratulations on your special day!");

            AnniversaryCard clonedAnniversaryCard = (AnniversaryCard)originalAnniversaryCard.Clone();
            clonedAnniversaryCard.SetRecipient("Eve and Frank");
            clonedAnniversaryCard.SetMessage("Wishing you many more happy years together!");

            Console.WriteLine("Original Birthday Card:");
            originalBirthdayCard.PrintCard();

            Console.WriteLine("Cloned Birthday Card:");
            clonedBirthdayCard.PrintCard();

            Console.WriteLine("Original Anniversary Card:");
            originalAnniversaryCard.PrintCard();

            Console.WriteLine("Cloned Anniversary Card:");
            clonedAnniversaryCard.PrintCard();
        }
    }

}
