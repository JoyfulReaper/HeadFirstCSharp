using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitsAndValues
{
    class Deck
    {
        private readonly Card[] cards = new Card[52];

        public Deck()
        {
            int index = 0;
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    cards[index++] = new Card((Values)value, (Suits)suit);
                }
            }
        }

        public void PrintCards()
        {
            for(int i = 0; i< cards.Length; i++)
            {
                Console.WriteLine(cards[i]);
            }
        }
    }
}
