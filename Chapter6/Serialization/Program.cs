using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main()
        {
            Stream stream = Tiger.Serialize();
            Console.WriteLine(new StreamReader(stream).ReadToEnd());
            Tiger.Deserialize(stream);
        }
    }
}
