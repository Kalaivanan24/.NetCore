using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class Singleton
    /*
     * sealed keyword will prevent inheritance of class and nested class, because if a nested class is present here, it will again create a new instance when it is called and the counter will increase to 2
     */
    {
        private static int counter = 0;//only when static the count value increases, if its private it doesn't
        private static readonly object obj = new object();
        private Singleton() //private constructor will prevent class from instantiating outside this class
        {
            counter++;
            Console.WriteLine("Count is " + counter);
        }
        //public static Singleton instance = null;
        public static readonly Lazy<Singleton> instance = new Lazy<Singleton>(()=> new Singleton());// this is for lazy singeton
        //public static readonly Singleton instance = new Singleton(); //this is for Eager Singleton
        public static Singleton GetInstance //its primary responsibility is to create Singleton instance. Since instance creation is delayed thru Get instance it is called Lazy initialization
        {
            get
            {
                //if (instance == null)// to avoid unneccessary lock checking we use this if statement. This double verification of null instance checking is called as Doubl check locking
                //{
                   // lock (obj)//this lock is used so that when 2 methods runs parallel and invoke the instance at the same time, this locks the instance creation for the first method to finish and goes to the next one
                    //{
                       // if (instance == null)
                            //instance = new Singleton();//this part is commented when we use lazy/eager instantiation
                   // }
               // }
                //return instance;// this is for eager singleton
                return instance.Value;//this is for lazy singleton
            }
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
        //public class DerivedClass : Singleton //don't use static here
        //{

        //}
    }
    
}
