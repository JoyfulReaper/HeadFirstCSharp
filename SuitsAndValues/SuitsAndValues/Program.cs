using System;

namespace SuitsAndValues
{
    class Program
    {
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            for (int i = 0; i < 1; i++)
            {
                Card card = new Card((Values)_random.Next((int)Values.Ace, (int)Values.King + 1), (Suits)_random.Next((int)Suits.Diamonds, (int)Suits.Spades + 1));
                Console.WriteLine(card);
            }

            Console.WriteLine();
            Deck deck = new Deck();
            deck.PrintCards();
        }
    }
}
