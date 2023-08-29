using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bank1 = new HDFC(100);
            var bank2 = new SBI(200);
            var bank3 = new AXIS(300);

            bank1.SetNext(bank2);
            bank2.SetNext(bank3);

            bank1.Pay((decimal)100);
        }

        abstract class Account
        {
            private Account mSuccessor;
            protected decimal mBalance;

            public void SetNext(Account account)
            {
                mSuccessor = account;
            }

            public void Pay(decimal amountTopay)
            {
                if (CanPay(amountTopay))
                {
                    Console.WriteLine($"Paid {amountTopay} using {this.GetType().Name}.");
                }
                else if (this.mSuccessor != null)
                {
                    Console.WriteLine($"Cannot pay using {this.GetType().Name}. Proceeding..");
                    mSuccessor.Pay(amountTopay);
                }
                else
                {
                    Console.WriteLine("None of the accounts have enough balance");
                }
            }
            private bool CanPay(decimal amount)
            {
                return mBalance >= amount;
            }
        }

        class HDFC : Account
        {
            public HDFC(decimal balance)
            {
                this.mBalance = balance;
            }
        }

        class SBI : Account
        {
            public SBI(decimal balance)
            {
                this.mBalance = balance;
            }
        }

        class AXIS : Account
        {
            public AXIS(decimal balance)
            {
                this.mBalance = balance;
            }
        }
    }
}





