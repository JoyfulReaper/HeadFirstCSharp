using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryClown
{
    class FunnyFunny : IClown
    {
        private readonly string _funnyThingIHave;

        public string FunnyThingIHave => _funnyThingIHave;

        public FunnyFunny(string thing)
        {
            _funnyThingIHave = thing;
        }

        public void Honk()
        {
            Console.WriteLine($"Hi kids! I have a {FunnyThingIHave}");
        }
    }
}
