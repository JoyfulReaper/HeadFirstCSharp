using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryClown
{
    interface IScaryClown : IClown
    {
        string ScaryThingIHave { get; }

        void ScareLittleChildren();

        void ScareAdults()
        {
            Console.WriteLine($@"I am an acient evil that will haunt your dreams.
Behold my terrifying necklace with {_random.Next(4, 10)} of my last victim's fingers.

Oh, also, before I forget...");
            ScareLittleChildren();
        }
    }
}
