using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"c:tempXmlFile.xml";
            ReadXmlFile(file);

            if (Debugger.IsAttached)
            {
                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        public static void ReadXmlFile(string filename)
        {
            try
            {
                bool readFileFlag = true;
                if (readFileFlag)
                {
                    File.ReadAllLines(filename);
                }
            }
            catch (Exception exception ) when (Log(exception))
            {
            }
        }

        private static bool Log(Exception exception)
        {
            Console.Error.WriteLine($"Error: {exception.Message}");
            return false;
        }
    }
}
