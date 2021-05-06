using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bird
{
    class Duck : Bird, IComparable<Duck>
    {
        public int Size { get; set; }
        public KindOfDuck Kind { get; set; }

        public int CompareTo(Duck other)
        {
            if(this.Size > other.Size)
            {
                return 1;
            }

            if (this.Size < other.Size)
            {
                return -1;
            }

            return 0;
        }

        public override string ToString() => $"A {Size} inch {Kind}";
    }
}
