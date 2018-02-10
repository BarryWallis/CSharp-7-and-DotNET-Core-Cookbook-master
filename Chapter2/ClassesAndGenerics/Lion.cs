using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ClassesAndGenerics
{
    public class Lion : Cat
    {
        public enum ColorSpectrum {  Brown, White }

        public string Color { get; set; }

        public Lion(ColorSpectrum color) => Color = color.ToString();

        public override void Eat() => WriteLine($"The {Color} lion eats.");
        public override void Hunt() => WriteLine($"The {Color} lion hunts.");
        public override void Sleep() => WriteLine($"The {Color} lion sleeps.");
    }
}
