using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldReturnDemo
{
    class ManualSportEnumerator : IEnumerator<Sports>
    {
        int _current = -1;

        public Sports Current { get { return (Sports)_current; } }

        object IEnumerator.Current { get { return Current; } }

        public void Dispose()
        {
            return;
        }

        public bool MoveNext()
        {
            var maxEnumVal = Enum.GetValues(typeof(Sports)).Length;
            if((int)Current >= maxEnumVal -1)
            {
                return false;
            }

            _current++;
            return true;
        }

        public void Reset()
        {
            _current = 0;
        }
    }
}
