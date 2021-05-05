using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    class DuckComparerBySize : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Size == y.Size)
            {
                return 0;
            }

            return x.Size < y.Size ? -1 : 1;
        }
    }
}
