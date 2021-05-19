using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDecksWPF
{
    class Card
    {
        public Values Value { get; set; }
        public Suits Suit { get; set; }
        public string Name => ToString();

        public Card(Values value, Suits suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString() => $"{Value} of {Suit}";
    }
}
