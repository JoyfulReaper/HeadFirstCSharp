using System;
using System.Linq;

namespace CardLinq
{
    class Program
    {
        private static string Output(Suits suit, int number) =>
            $"Suit is {suit} and number is {number}";

        static void Main(string[] args)
        {

            var deck3 = new Deck();
            var processedCards = deck3
                .Take(3)
                .Concat(deck3.TakeLast(3))
                .OrderByDescending(card => card)
                .Select(card => card.Value switch
                {
                    Values.King => Output(card.Suit, 7),
                    Values.Ace => $"It's an ace! {card.Suit}",
                    Values.Jack => Output((Suits)card.Suit -1, 9),
                    Values.Two => Output(card.Suit, 18),
                    _ => card.ToString(),
                });

            foreach(var output in processedCards)
            {
                Console.WriteLine(output);
            }
            return;
            /////////////////////////////
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
