using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {

        public class PrinterSpooler
        {
            private static PrinterSpooler instance;

            private PrinterSpooler() { } // Private constructor

            public static PrinterSpooler Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new PrinterSpooler();
                    }
                    return instance;
                }
            }

            public void PrintDocument(string document)
            {
                Console.WriteLine($"Printing document: {document}");
            }
        }



       
            static void Main(string[] args)
            {
                PrinterSpooler spooler1 = PrinterSpooler.Instance;
                spooler1.PrintDocument("Report.pdf");

                PrinterSpooler spooler2 = PrinterSpooler.Instance;
                spooler2.PrintDocument("Invoice.docx");
            }
        }

    }

