using System;
using System.Linq;
using System.Collections.Generic;

namespace JimmyLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            TheOtherDemo();
            Console.WriteLine();

            IEnumerable<Comic> mostExpensive =
                from comic in Comic.Catalog
                where Comic.Prices[comic.Issue] > 500
                orderby Comic.Prices[comic.Issue] descending
                select comic;

            foreach(Comic comic in mostExpensive)
            {
                Console.WriteLine($"{comic} is worth {Comic.Prices[comic.Issue]:c}");
            }

            Console.WriteLine();

            IEnumerable<string> mostExpensiveDescription =
                from comic in Comic.Catalog
                where Comic.Prices[comic.Issue] > 500
                orderby Comic.Prices[comic.Issue] descending
                select $"{comic} is worth {Comic.Prices[comic.Issue]:c}";

            foreach (string comic in mostExpensiveDescription)
            {
                Console.WriteLine($"{comic}");
            }
        }

        private static void TheOtherDemo()
        {
            Random rand = new();

            var sandwiches = new[] { "ham and cheese", "salami with mayo", "turkey and swiss", "chicken cutlet" };
            var breads = new[] { "rye", "white", "wheat", "sour dough", "pumpernickel" };

            var bread = breads[rand.Next(0, breads.Length)];

            var todaysSpecial =
                from sandwich in sandwiches
                select $"{sandwich} on {bread}";

            foreach(var s in todaysSpecial)
            {
                Console.WriteLine(s);
            }
        }
    }
}
