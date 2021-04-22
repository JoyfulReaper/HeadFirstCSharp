using System;
using System.Collections.Generic;

// Improvement over the book example :D
// It is only Chapter 3 after all o_O

namespace PickRandomCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of cards to pick: ");
            string consoleInput = Console.ReadLine();

            if(int.TryParse(consoleInput, out int numberOfCards))
            {
                OutputRandomCards(numberOfCards);
            }
            else
            {
                Console.WriteLine($"{consoleInput} is not a valid number! Please enter a valid number!");
                Main(args);
            }
        }

        private static void OutputRandomCards(int numberOfCards)
        {
            Card[] cardArray = CardPicker.PickSomeCards(numberOfCards);
            List<Card> cardList = CardPicker.PickSomeCardsList(numberOfCards);

            Console.WriteLine("Array of Random Card Objects: ");
            foreach(Card c in cardArray)
            {
                Console.WriteLine(c.DisplayName);
            }

            Console.WriteLine("\nList of Random Card Objects: ");
            foreach (Card c in cardList)
            {
                Console.WriteLine(c.DisplayName);
            }
        }
    }
}
