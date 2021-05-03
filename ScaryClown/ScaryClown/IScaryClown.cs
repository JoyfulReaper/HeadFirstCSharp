using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryClown
{
    interface IScaryClown : IClown
    {
        public string ScaryThingIHave { get; }

        public void ScareLittleChildren();
    }
}
