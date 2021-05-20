using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoDecksBlazor
{
    class TwoDecks
    {
        private Deck leftDeck = new Deck();
        public int LeftDeckCount { get => leftDeck.Count; }
        public int LeftCardSelected { get; set; }

        public string LeftDeckCardName(int i)
        {
            return leftDeck[i].ToString();
        }

        public void Shuffle()
        {
            leftDeck.Shuffle();
        }

        public void Reset()
        {
            leftDeck = new Deck();
        }
    }
}
