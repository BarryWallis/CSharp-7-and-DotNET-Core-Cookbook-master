using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ClassesAndGenerics
{
    public class Tiger : Cat
    {
        public enum ColorSpectrum { Orange, White, Gold, Blue, Black }

        public string Color { get; set; }

        public Tiger(ColorSpectrum color) => Color = color.ToString();

        public override void Eat() => WriteLine($"The {Color} tiger eats.");
        public override void Hunt() => WriteLine($"The {Color} tiger hunts.");
        public override void Sleep() => WriteLine($"The {Color} tiger sleeps.");
    }
}
