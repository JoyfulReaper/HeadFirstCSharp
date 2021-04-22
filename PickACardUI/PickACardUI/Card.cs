using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickACardUI
{
    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public string DisplayName => $"{Value} of {Suit}";
    }
}
