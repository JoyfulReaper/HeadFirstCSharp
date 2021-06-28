using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldReturnDemo
{
    class ManualSportSequence : IEnumerable<Sports>
    {
        public IEnumerator<Sports> GetEnumerator()
        {
            return new ManualSportEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
