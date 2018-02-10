using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndGenerics
{
    public class MyHelperClass
    {
        public T InspectType<T>(T value)
        {
            Console.WriteLine($"The data type of the supplied parameter is {value.GetType()}");
            return value;
        }
    }
}
