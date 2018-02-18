using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExampleApp
{
    class Program
    {
        static void Main()
        {
            List<LambdaExample> myFavoriteThings = new List<LambdaExample>();

            LambdaExample thing1 = new LambdaExample
            {
                FavoriteThing = "Ice Cream"
            };
            myFavoriteThings.Add(thing1);

            LambdaExample thing2 = new LambdaExample
            {
                FavoriteThing = "Summer Rain"
            };
            myFavoriteThings.Add(thing2);

            LambdaExample thing3 = new LambdaExample
            {
                FavoriteThing = "Sunday monring snooze"
            };
            myFavoriteThings.Add(thing3);

            IEnumerable<LambdaExample> filteredThings = myFavoriteThings
                .Where(thing => thing.FavoriteThing.StartsWith("Sum"));

            if (Debugger.IsAttached)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
