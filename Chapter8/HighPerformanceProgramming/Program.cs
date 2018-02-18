using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HighPerformanceProgramming
{
    class Program
    {
        static void Main()
        {
            Demo.LockThreadExample();

            if (Debugger.IsAttached)
            {
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
