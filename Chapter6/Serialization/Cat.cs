using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    public class Cat
    {
        private int weight;
        private int age;

        public int Weight { get => weight; set => weight = value; }
        public int Age { get => age; set => age = value; }
    }
}
