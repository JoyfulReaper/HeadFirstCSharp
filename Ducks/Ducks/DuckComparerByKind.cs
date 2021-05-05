using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    class DuckComparerByKind : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Kind == y.Kind)
            {
                return 0;
            }

            return x.Kind < y.Kind ? -1 : 1;
        }
    }
}
