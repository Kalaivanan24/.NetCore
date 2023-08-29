using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Program
    {
        public interface IPizza
        {
            void AddTopping(string topping);
            string GetPizzaInfo();
        }
        public class Pizza : IPizza
        {
            private List<string> toppings = new List<string>();
            public void AddTopping(string topping)
            {
                toppings.Add(topping);
            }

            public string GetPizzaInfo()
            {
                string toppingsList = string.Join(", ", toppings);
                return $"Pizza with {toppingsList} toppings.";
            }
        }
        public interface IPizzaBuilder
        {
            void BuildDough();
            void BuildSauce();
            void BuildToppings();
            IPizza GetPizza();
        }
        public class MargheritaPizzaBuilder : IPizzaBuilder
        {
            private IPizza pizza = new Pizza();

            public void BuildDough()
            {
                pizza.AddTopping("thin crust dough");
            }

            public void BuildSauce()
            {
                pizza.AddTopping("tomato sauce");
            }

            public void BuildToppings()
            {
                pizza.AddTopping("mozzarella cheese");
            }

            public IPizza GetPizza()
            {
                return pizza;
            }
        }

        public class VeggieSupremePizzaBuilder : IPizzaBuilder
        {
            private IPizza pizza = new Pizza();

            public void BuildDough()
            {
                pizza.AddTopping("thick crust dough");
            }

            public void BuildSauce()
            {
                pizza.AddTopping("spicy sauce");
            }
            public void BuildToppings()
            {
                pizza.AddTopping("bell peppers, onions, olives");
            }
            public IPizza GetPizza()
            {
                return pizza;
            }
        }
        public class PizzaCook
        {
            public IPizza MakePizza(IPizzaBuilder builder)
            {
                builder.BuildDough();
                builder.BuildSauce();
                builder.BuildToppings();
                return builder.GetPizza();
            }
        }


        static void Main()
        {
            PizzaCook cook = new PizzaCook();

            IPizzaBuilder margheritaBuilder = new MargheritaPizzaBuilder();
            IPizza margheritaPizza = cook.MakePizza(margheritaBuilder);
            Console.WriteLine("Margherita Pizza:");
            Console.WriteLine(margheritaPizza.GetPizzaInfo());

            IPizzaBuilder veggieBuilder = new VeggieSupremePizzaBuilder();
            IPizza veggiePizza = cook.MakePizza(veggieBuilder);
            Console.WriteLine("\nVeggie Supreme Pizza:");
            Console.WriteLine(veggiePizza.GetPizzaInfo());
        }
    }
}
