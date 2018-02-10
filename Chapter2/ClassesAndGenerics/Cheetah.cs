using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ClassesAndGenerics
{
    public class Cheetah : Cat, IPurrable
    {
        public override void Eat() => WriteLine($"The cheetah eats.");

        public override void Hunt() => WriteLine($"The cheetah hunts.");

        public override void Sleep() => WriteLine($"The cheetah sleeps.");

        public void SoftPurr(int decibel) => WriteLine($"The {nameof(Cheetah)} purrs at {decibel} decibels.");
    }
}
