using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    class Duck : IComparable<Duck>
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
    }
}
