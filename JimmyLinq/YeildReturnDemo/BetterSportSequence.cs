using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldReturnDemo
{
    class BetterSportSequence : IEnumerable<Sports>
    {
        public IEnumerator<Sports> GetEnumerator()
        {
            int maxEnumValue = Enum.GetValues(typeof(Sports)).Length - 1;
            for(int i = 0; i <= maxEnumValue; i++)
            {
                yield return (Sports)i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Sports this[int index]
        {
            get => (Sports)index;
        }
    }
}
