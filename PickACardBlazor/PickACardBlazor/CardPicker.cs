using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickACardBlazor
{
    public class CardPicker
    {
        static Random _random = new Random();

        public static Card[] PickSomeCards(int numberOfCards)
        {
            Card[] pickedCards = new Card[numberOfCards];

            for(int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = new Card() { Suit = RandomSuit(), Value = RandomValue() };
            }

            return pickedCards;
        }

        private static string RandomSuit()
        {
            int value = _random.Next(1, 5);

            switch (value)
            {
                case 1:
                    return "Spades";
                case 2:
                    return "Hearts";
                case 3:
                    return "Clubs";
                default:
                    return "Diamonds";
            }
        }

        private static string RandomValue()
        {
            int value = _random.Next(1, 14);
            switch (value)
            {
                case 1:
                    return "Ace";
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                default:
                    return value.ToString();
            }
        }

        public static List<Card> PickSomeCardsList(int numberOfCards)
        {
            List<Card> pickedCards = new List<Card>();

            for(int i = 0; i < numberOfCards; i++)
            {
                pickedCards.Add(new Card() { Suit = RandomSuit(), Value = RandomValue() });
            }

            return pickedCards;
        }
    }
}
