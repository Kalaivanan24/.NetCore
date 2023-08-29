using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        
        
            static void Main(string[] args)
            {
                List<Item> items = new List<Item>
        {
            new Book(),
            new Clothing()
        };

                var summerVisitor = new SummerSaleVisitor();
                var winterVisitor = new WinterSaleVisitor();

                foreach (var item in items)
                {
                    item.Accept(summerVisitor);
                    item.Accept(winterVisitor);
                    Console.WriteLine();
                }
            }
        }

        abstract class Item
        {
            public abstract void Accept(IDiscountVisitor visitor);
            public abstract double Price { get; }
        }

        class Book : Item
        {
            public override double Price => 20;

            public override void Accept(IDiscountVisitor visitor)
            {
                visitor.VisitBook(this);
            }
        }

        class Clothing : Item
        {
            public override double Price => 50;

            public override void Accept(IDiscountVisitor visitor)
            {
                visitor.VisitClothing(this);
            }
        }


        interface IDiscountVisitor
        {
            void VisitBook(Book book);
            void VisitClothing(Clothing clothing);
        }


        class SummerSaleVisitor : IDiscountVisitor
        {
            public void VisitBook(Book book)
            {
                Console.WriteLine($"Applying 10% discount on book. Final price: {book.Price * 0.9}");
            }

            public void VisitClothing(Clothing clothing)
            {
                Console.WriteLine($"Applying 20% discount on clothing. Final price: {clothing.Price * 0.8}");
            }
        }

        class WinterSaleVisitor : IDiscountVisitor
        {
            public void VisitBook(Book book)
            {
                Console.WriteLine($"Applying 5% discount on book. Final price: {book.Price * 0.95}");
            }

            public void VisitClothing(Clothing clothing)
            {
                Console.WriteLine($"Applying 30% discount on clothing. Final price: {clothing.Price * 0.7}");
            }
        }

}
