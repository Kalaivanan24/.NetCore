using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    internal class Program
    {
        public class NumberContext
        {
            public int Number { get; set; }
            public string Result { get; set; } = string.Empty;

            public NumberContext(int number)
            {
                Number = number;
            }
        }


        public interface INumberExpression
        {
            void Interpret(NumberContext context);
        }


        public class NumberExpression : INumberExpression
        {
            public void Interpret(NumberContext context)
            {
                var stringNumber = context.Number.ToString();

                var numberTranslations = new string[]
                {
            "Zero","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
                };

                foreach (var character in stringNumber)
                {
                    context.Result += $"{numberTranslations[int.Parse(character.ToString())]}-";
                }
                context.Result = context.Result.Remove(context.Result.Length - 1);
            }
        }




        static void Main(string[] args)
        {

            int numberToInterpret = 27;

            NumberContext context = new NumberContext(numberToInterpret);
            INumberExpression expression = new NumberExpression();

            expression.Interpret(context);

            Console.WriteLine($"Number: {context.Number}");
            Console.WriteLine($"Interpretation: {context.Result}");
        }
    }
}
