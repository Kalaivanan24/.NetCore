using System;
using System.Security.Cryptography.X509Certificates;

namespace Singleton
{
    class Program
    {
        public static void Main(string[] args)
        {
            //PrintEmployeeDetails();
            //PrintColleagueDetails();
            Parallel.Invoke(() => PrintEmployeeDetails(),
                            () => PrintColleagueDetails());
            
            //Singleton.DerivedClass d = new Singleton.DerivedClass();
            //d.PrintDetails("printing d");
        }

        private static void PrintColleagueDetails()
        {
            Singleton colleague = Singleton.GetInstance;
            colleague.PrintDetails("From colleague");
        }

        private static void PrintEmployeeDetails()
        {
            Singleton employee = Singleton.GetInstance;
            employee.PrintDetails("From employee");
        }
    }
}
