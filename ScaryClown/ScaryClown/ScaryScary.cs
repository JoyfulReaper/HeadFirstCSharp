using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryClown
{
    class ScaryScary : FunnyFunny, IScaryClown
    {
        private readonly int _scaryThingCount;

        public string ScaryThingIHave => $"{_scaryThingCount} spiders";

        public ScaryScary(string funnyThing, int count) : base(funnyThing)
        {
            _scaryThingCount = count;
        }

        public void ScareLittleChildren()
        {
            Console.WriteLine($"Boo! Gotcha! Look at my {ScaryThingIHave}!");
        }
    }
}
