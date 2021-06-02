﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace JimmyLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            AnotherDemo();
            Console.WriteLine();
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

        private static void AnotherDemo()
        {
            Random rand = new();

            var numbers = new List<int>();
            int length = rand.Next(50, 150 + 1);
            for(int i = 0; i < length; i++)
            {
                numbers.Add(rand.Next(100 + 1));
            }

            Console.WriteLine($@"Stats for these {numbers.Count()} numbers:
The first 5 numbers: {String.Join(", ", numbers.Take(5))}
The last 5 numbers: {String.Join(", ", numbers.TakeLast(5))}
The first number is {numbers.First()} and the last is {numbers.Last()}
The smallest is {numbers.Min()}, and the biggest is {numbers.Max()}
The sum is {numbers.Sum()}
The average is {numbers.Average():F2}");
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
