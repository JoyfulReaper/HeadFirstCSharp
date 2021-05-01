using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clowns
{
    interface IClown
    {
        public string FunnyThingIHave { get; }
        void Honk();
    }
}
