using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Program
    {
        public abstract class BeverageTemplate
        {
            public void MakeBeverage()
            {
                BoilWater();
                Brew();
                PourInCup();
                AddCondiments();
            }

            protected void BoilWater()
            {
                Console.WriteLine("Boiling water");
            }

            protected abstract void Brew();

            protected void PourInCup()
            {
                Console.WriteLine("Pouring into cup");
            }

            protected abstract void AddCondiments();
        }

        public class Tea : BeverageTemplate
        {
            protected override void Brew()
            {
                Console.WriteLine("Steeping the tea");
            }

            protected override void AddCondiments()
            {
                Console.WriteLine("Adding sugar");
            }
        }

        public class Coffee : BeverageTemplate
        {
            protected override void Brew()
            {
                Console.WriteLine("Dripping coffee through filter");
            }

            protected override void AddCondiments()
            {
                Console.WriteLine("Adding sugar and milk");
            }
        }

       
            static void Main(string[] args)
            {
                Console.WriteLine("Making tea:");
                BeverageTemplate tea = new Tea();
                tea.MakeBeverage();

                Console.WriteLine("\nMaking coffee:");
                BeverageTemplate coffee = new Coffee();
                coffee.MakeBeverage();
            }
        }


    }

