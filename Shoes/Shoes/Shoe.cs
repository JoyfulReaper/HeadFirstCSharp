using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoes
{
    class Shoe
    {
        public Style Style { get; private set; }
        public string Color { get; private set; }
        public string Description => ToString();

        public Shoe(Style style, string color)
        {
            Style = style;
            Color = color;
        }

        public override string ToString() => $"A {Color} {Style}";
    }
}
