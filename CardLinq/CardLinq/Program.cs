using System;
using System.Linq;

namespace CardLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck()
                .Shuffle()
                .Take(16);

            var grouped =
                from card in deck
                group card by card.Suit into suitGroup
                orderby suitGroup.Key descending
                select suitGroup;

            var deck2 = new Deck();
            var grouped2 =
                deck2.Shuffle()
                .Take(16)
                .GroupBy(x => x.Suit)
                .OrderByDescending(x => x.Key);

            foreach (var group in grouped)
            {
                Console.WriteLine($@"Group: {group.Key}
Count: {group.Count()}
Minumum: {group.Min()}
Maximum: {group.Max()}" + "\n");
            }

            Console.WriteLine("Method chanining: ");
            foreach (var group in grouped2)
            {
                Console.WriteLine($@"Group: {group.Key}
Count: {group.Count()}
Minumum: {group.Min()}
Maximum: {group.Max()}" + "\n");
            }
        }
    }
}
