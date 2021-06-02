using System;
using System.Linq;
using System.Collections.Generic;

namespace JimmyLinq
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}
