﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLinq
{
    class Card : IComparable<Card>
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

        public int CompareTo(Card other)
        {
            return new CardComparerByValue().Compare(this, other);
        }
    }
}
