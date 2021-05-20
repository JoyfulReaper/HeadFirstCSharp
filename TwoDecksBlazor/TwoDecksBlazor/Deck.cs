using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoDecksBlazor
{
    class Deck : List<Card>
    {
        private static readonly Random _random = new Random();

        public Deck()
        {
            Reset();
        }

        public void Reset()
        {
            Clear();

            for(int i = 0; i < 4; i++)
            {
                for(int j = 1; j <= 13; j++)
                {
                    Add(new Card((Values)j, (Suits)i));
                }
            }
        }

        public void Shuffle()
        {
            List<Card> copy = new List<Card>(this);
            Clear();

            while(copy.Count > 0)
            {
                var index = _random.Next(copy.Count);
                var card = copy[index];
                copy.RemoveAt(index);
                Add(card);
            }
        }

        public Card Deal (int index)
        {
            var card = base[index];
            RemoveAt(index);
            return card;
        }
    }
}
