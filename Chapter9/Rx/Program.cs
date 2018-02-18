using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rx
{
    class Program
    {
        static event Action<string> TypesEvents;
        static Subject<string> typesSubject = new Subject<string>();


        static void Main()
        {
            List<DotNet> dotNetTypes = new List<DotNet>();

            DotNet boolTypes = new DotNet
            {
                AvailableDataType = "bool"
            };
            dotNetTypes.Add(boolTypes);

            DotNet stringTypes = new DotNet
            {
                AvailableDataType = "string"
            };
            dotNetTypes.Add(stringTypes);

            DotNet intTypes = new DotNet
            {
                AvailableDataType = "int"
            };
            dotNetTypes.Add(intTypes);

            DotNet decimalTypes = new DotNet
            {
                AvailableDataType = "decimal"
            };
            dotNetTypes.Add(decimalTypes);

            typesSubject.Subscribe(x =>
            {
                Console.WriteLine($"{x}");
            });

            foreach (DotNet type in dotNetTypes)
            {
                typesSubject.OnNext(type.AvailableDataType);
            }

            if (Debugger.IsAttached)
            {
                Console.Write($"\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }

    public class DotNet
    {
        public string AvailableDataType { get; set; }
    }
}
