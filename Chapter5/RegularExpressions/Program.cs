using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RegularExpressions
{
    class Program
    {
        static void Main()
        {
            #region Validation
            //RegexDemo.ValidDate("1912-12-31");
            //RegexDemo.ValidDate("2018-01-01");
            //RegexDemo.ValidDate("1800-01-21");
            //RegexDemo.ValidDate($"{DateTime.Now.Year}.{DateTime.Now.Month}.{DateTime.Now.Day}");
            //RegexDemo.ValidDate("2016-21-12");
            #endregion

            #region Sanitize Input
            //string textToSanitize = "This is a string that contains a badword1, another Badword2 and a third badWord3";
            //Console.WriteLine(RegexDemo.SanitizeINput(textToSanitize));
            #endregion

            #region Dynamic Regex Matching
            DemoExtensionMethod();
            #endregion

            if (Debugger.IsAttached)
            {
                Console.Write($"\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        #region Dynamic Regex Matching
        public static void DemoExtensionMethod()
        {
            WriteLine($"Today's date is {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}");
            WriteLine($"The file must match: acm_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.txt including leading month and day zeros.");
            WriteLine($"The file must match: acm_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.docx including leading month and day zeros.");
            WriteLine($"The file must match: acm_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.xlsx including leading month and day zeros.");

            string filename = $"acm_{DateTime.Now.Year}_{DateTime.Now.Month.ToString("D2")}_{DateTime.Now.Day.ToString("D2")}.txt";
            if (filename.ValidAcmeCompanyFilename())
            {
                WriteLine($"{filename} is a valid file name");
            }
            else
            {
                WriteLine($"{filename} is not a valid file name");
            }

            filename = $"acm-{DateTime.Now.Year}_{DateTime.Now.Month.ToString("D2")}_{DateTime.Now.Day.ToString("D2")}.txt";
            if (filename.ValidAcmeCompanyFilename())
            {
                WriteLine($"{filename} is a valid file name");
            }
            else
            {
                WriteLine($"{filename} is not a valid file name");
            }
        }
        #endregion

    }
}
