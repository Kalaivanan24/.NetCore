using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Program
    {

        public interface IBeverage
        {
            string GetDescription();
            double GetCost();
        }
        public class Coffee : IBeverage
        {
            public string GetDescription()
            {
                return "Coffee";
            }

            public double GetCost()
            {
                return 2.0;
            }
        }

        public abstract class CondimentDecorator : IBeverage
        {
            protected IBeverage _beverage;

            public CondimentDecorator(IBeverage beverage)
            {
                _beverage = beverage;
            }

            public abstract string GetDescription();
            public abstract double GetCost();
        }
        public class MilkDecorator : CondimentDecorator
        {
            public MilkDecorator(IBeverage beverage) : base(beverage) { }

            public override string GetDescription()
            {
                return _beverage.GetDescription() + ", Milk";
            }

            public override double GetCost()
            {
                return _beverage.GetCost() + 0.5;
            }
        }

        public class SugarDecorator : CondimentDecorator
        {
            public SugarDecorator(IBeverage beverage) : base(beverage) { }

            public override string GetDescription()
            {
                return _beverage.GetDescription() + ", Sugar";
            }

            public override double GetCost()
            {
                return _beverage.GetCost() + 0.2;
            }
        }


        static void Main(string[] args)
        {
            IBeverage coffee = new Coffee();
            Console.WriteLine("Base beverage: " + coffee.GetDescription() + " $" + coffee.GetCost());

            IBeverage milkCoffee = new MilkDecorator(coffee);
            Console.WriteLine("With milk: " + milkCoffee.GetDescription() + " $" + milkCoffee.GetCost());

            IBeverage sugarMilkCoffee = new SugarDecorator(milkCoffee);
            Console.WriteLine("With sugar: " + sugarMilkCoffee.GetDescription() + " $" + sugarMilkCoffee.GetCost());
        }
    }

}
