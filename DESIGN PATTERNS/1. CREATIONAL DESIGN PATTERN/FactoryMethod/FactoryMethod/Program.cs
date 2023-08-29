using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        interface IFood
        {
            string Describe();
        }
        class Pizza : IFood
        {
            public string Describe()
            {
                return "Delicious pizza!";
            }
        }

        class Burger : IFood
        {
            public string Describe()
            {
                return "Tasty burger!";
            }
        }


        class FoodFactory
        {
            public IFood CreateFood(string type)
            {
                if (type == "Pizza")
                {
                    return new Pizza();
                }
                else if (type == "Burger")
                {
                    return new Burger();
                }
                else
                {
                    throw new ArgumentException("Invalid food type");
                }
            }
        }

        static void Main(string[] args)
        {
            FoodFactory factory = new FoodFactory();

            IFood pizza = factory.CreateFood("Pizza");
            IFood burger = factory.CreateFood("Burger");

            Console.WriteLine(pizza.Describe());  // Output: Delicious pizza!
            Console.WriteLine(burger.Describe()); // Output: Tasty burger!
        }
    }
}
