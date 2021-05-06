using System;
using System.Collections.Generic;
using System.Linq;

namespace JumbledCards
{
    class Program
    {
        static readonly Random _random = new();
        static readonly List<Card> _cards = new();

        static void Main(string[] args)
        {
            Console.Write("Enter number of cards: ");
            

            if(int.TryParse(Console.ReadLine(), out int numberOfCards))
            {
                for(int i = 0; i < numberOfCards; i++)
                {
                    _cards.Add(RandomCard());
                }
            }

            Console.WriteLine();
            PrintCards(_cards);

            _cards.Sort(new CardComparerByValue());
            Console.WriteLine("\n... sorting the cards ...\n");

            PrintCards(_cards);

        }

        static Card RandomCard()
        {
            int[] cardValues = (int[]) Enum.GetValues(typeof(Values));
            int[] cardSuits = (int[]) Enum.GetValues(typeof(Suits));

            return new Card((Values)_random.Next(cardValues.Min(), cardValues.Max() + 1),
                (Suits)_random.Next(cardSuits.Min(), cardSuits.Max() + 1));
        }

        static void PrintCards(List<Card> cards)
        {
            foreach(Card c in cards)
            {
                Console.WriteLine(c);
            }
        }
    }
}
