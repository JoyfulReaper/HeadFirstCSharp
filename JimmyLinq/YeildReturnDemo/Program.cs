using System;
using System.Collections.Generic;

namespace YieldReturnDemo
{
    class Program
    {
        static IEnumerable<string> SimpleEnumberable()
        {
            yield return "apples";
            yield return "oranges";
            yield return "bananas";
            yield return "unicorns";
        }

        static void Main(string[] args)
        {
            foreach(var p in new PowersOfTwoDemo())
            {
                Console.Write(p + " ");
            }

            Console.WriteLine();

            var betterSports = new BetterSportSequence();
            Console.WriteLine("sports[3]: " + betterSports[3]);

            foreach (var f in SimpleEnumberable())
            {
                Console.WriteLine(f);
            }

            Console.WriteLine();

            var sports = new ManualSportSequence();
            foreach (var s in sports)
            {
                Console.WriteLine(s);
            }
        }
    }
}
