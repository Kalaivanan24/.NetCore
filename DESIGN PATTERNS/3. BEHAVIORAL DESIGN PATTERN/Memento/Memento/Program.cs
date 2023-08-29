using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class Program
    {

        class Calculator
        {
            private List<string> calculationHistory = new List<string>();

            public void AddCalculation(string calculation)
            {
                calculationHistory.Add(calculation);
            }

            public List<string> GetCalculationHistory()
            {
                return new List<string>(calculationHistory);
            }

            public CalculatorMemento SaveHistory()
            {
                return new CalculatorMemento(new List<string>(calculationHistory));
            }

            public void RestoreHistory(CalculatorMemento memento)
            {
                calculationHistory = new List<string>(memento.GetState());
            }

            public void DisplayHistory()
            {
                Console.WriteLine("Calculation History:");
                foreach (var calculation in calculationHistory)
                {
                    Console.WriteLine(calculation);
                }
            }
        }

        class CalculatorMemento
        {
            private readonly List<string> state;

            public CalculatorMemento(List<string> history)
            {
                state = new List<string>(history);
            }

            public List<string> GetState()
            {
                return state;
            }
        }


        class HistoryTracker
        {
            private List<CalculatorMemento> mementos = new List<CalculatorMemento>();

            public void SaveMemento(CalculatorMemento memento)
            {
                mementos.Add(memento);
            }

            public CalculatorMemento GetMemento(int index)
            {
                return mementos[index];
            }
        }



        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            HistoryTracker history = new HistoryTracker();

            calculator.AddCalculation("5 + 3 = 8");
            history.SaveMemento(calculator.SaveHistory());

            calculator.AddCalculation("10 * 2 = 20");
            history.SaveMemento(calculator.SaveHistory());

            calculator.DisplayHistory();

            calculator.RestoreHistory(history.GetMemento(0));
            calculator.DisplayHistory();

            calculator.RestoreHistory(history.GetMemento(1));
            calculator.DisplayHistory();
        }
    }

}
