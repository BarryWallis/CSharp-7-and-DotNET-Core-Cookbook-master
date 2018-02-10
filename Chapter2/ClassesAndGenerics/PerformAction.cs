using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndGenerics
{
    public class PerformAction<T> where T : IDisposable
    {
        private T value;

        public PerformAction(T value) => this.value = value;

        public void IdentifyDataType() => Console.WriteLine($"The data type of the supplied variable is {value.GetType()}");
    }
}
