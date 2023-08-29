using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Program
    {

        public interface IDiscountStrategy
        {
            double ApplyDiscount(double originalPrice);
        }
        public class NoDiscountStrategy : IDiscountStrategy
        {
            public double ApplyDiscount(double originalPrice)
            {
                return originalPrice;
            }
        }

        public class PercentageDiscountStrategy : IDiscountStrategy
        {
            private double _percentage;

            public PercentageDiscountStrategy(double percentage)
            {
                _percentage = percentage;
            }

            public double ApplyDiscount(double originalPrice)
            {
                return originalPrice * (1 - _percentage / 100);
            }
        }

        public class FixedAmountDiscountStrategy : IDiscountStrategy
        {
            private double _amount;

            public FixedAmountDiscountStrategy(double amount)
            {
                _amount = amount;
            }

            public double ApplyDiscount(double originalPrice)
            {
                return originalPrice - _amount;
            }
        }

        public class ShoppingCart
        {
            private IDiscountStrategy _discountStrategy;

            public ShoppingCart(IDiscountStrategy discountStrategy)
            {
                _discountStrategy = discountStrategy;
            }

            public double CalculateTotalPrice(double originalPrice)
            {
                return _discountStrategy.ApplyDiscount(originalPrice);
            }
        }

      
            static void Main(string[] args)
            {
                double originalPrice = 100.0;

                IDiscountStrategy noDiscount = new NoDiscountStrategy();
                IDiscountStrategy tenPercentDiscount = new PercentageDiscountStrategy(10);
                IDiscountStrategy twentyDollarsDiscount = new FixedAmountDiscountStrategy(20);

                ShoppingCart cart1 = new ShoppingCart(noDiscount);
                ShoppingCart cart2 = new ShoppingCart(tenPercentDiscount);
                ShoppingCart cart3 = new ShoppingCart(twentyDollarsDiscount);

                Console.WriteLine("Cart 1 Total Price: $" + cart1.CalculateTotalPrice(originalPrice));
                Console.WriteLine("Cart 2 Total Price: $" + cart2.CalculateTotalPrice(originalPrice));
                Console.WriteLine("Cart 3 Total Price: $" + cart3.CalculateTotalPrice(originalPrice));
            }
        }


    }

