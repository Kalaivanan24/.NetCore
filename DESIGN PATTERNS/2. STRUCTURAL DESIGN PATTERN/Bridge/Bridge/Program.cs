using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Program
    {

        interface IWebsite
        {
            string GetContent();
        }

        class CodePage : IWebsite
        {
            protected ITheme theme;

            public CodePage(ITheme theme)
            {
                this.theme = theme;
            }

            public string GetContent()
            {
                return $"Code page in {theme.GetColor()}";
            }
        }

        class OutputPage : IWebsite
        {
            protected ITheme theme;

            public OutputPage(ITheme theme)
            {
                this.theme = theme;
            }

            public string GetContent()
            {
                return $"Output page in {theme.GetColor()}";
            }
        }


        interface ITheme
        {
            string GetColor();
        }

        class DarkTheme : ITheme
        {
            public string GetColor()
            {
                return "Dark Mode";
            }
        }

        class LightTheme : ITheme
        {
            public string GetColor()
            {
                return "Light Mode";
            }
        }

        static void Main(string[] args)
        {
            var darkTheme = new DarkTheme();
            var lightTheme = new LightTheme();

            var codepage = new CodePage(lightTheme);
            var outputpage = new OutputPage(darkTheme);

            Console.WriteLine(codepage.GetContent()); 
            Console.WriteLine(outputpage.GetContent()); 
        }
    }
}
